/***************************************************************************
 *   Copyright (C) 2009 by Stanson <stanson@pangolin.ru>                   *
 *   GPL v3 code, read COPYING file                                        *
 **************************************************************************/
/***************************************************************************
 *	 Some chages and additional functionality by Soaron	2019		   *
 **************************************************************************/

#include <pic18fregs.h>
#include "usb.h"
#include "config.h"
#include "main.h"

__data __at (0x408) BDT ep1Bo;		//Endpoint #1 BD Out
__data __at (0x40C) BDT ep1Bi;		//Endpoint #1 BD In

#pragma udata bank5 dataIN
byte dataIN[OSC_EP_SIZE];
#pragma udata bank6 dataOUT
byte dataOUT[OSC_EP_SIZE];
#pragma udata bank7 osc_data
byte osc_data[256];

byte cnt, cnt2, cnt3;
byte delay, delayhi;
byte timescale; /* 4.2 us, 10.6 us, 20 us, 50 us, 0.1 ms, 0.2 ms, 0.5 ms */
byte sync;
byte sens, shutt, div100;
byte set_test;

extern byte           usb_device_state;	// Device States: DETACHED, ATTACHED, ...

#pragma stack 0x200 255

#pragma code _reset 0x800
void _reset (void) __naked
{
    /* Установить стек и перейти на начало */
    __asm
    LFSR 1, _stack_end
    GOTO _main
    __endasm;
}

#pragma code _high_ISR 0x808
void _high_ISR (void) __naked
{
    __asm
    GOTO _high_interrupt
    __endasm;
}

#pragma code _low_ISR 0x818
void _low_ISR (void) __naked
{
    __asm
    GOTO _low_interrupt
    __endasm;
}


void high_interrupt(void) __interrupt
{
}

void low_interrupt(void) __interrupt
{
}

#define GET_8BYTES \
      __asm 			MOVFF	_PORTB, _POSTINC0 	__endasm; \
      __asm 			MOVFF	_PORTB, _POSTINC0 	__endasm; \
      __asm 			MOVFF	_PORTB, _POSTINC0 	__endasm; \
      __asm 			MOVFF	_PORTB, _POSTINC0 	__endasm; \
      __asm 			MOVFF	_PORTB, _POSTINC0 	__endasm; \
      __asm 			MOVFF	_PORTB, _POSTINC0 	__endasm; \
      __asm 			MOVFF	_PORTB, _POSTINC0 	__endasm; \
      __asm 			MOVFF	_PORTB, _POSTINC0 	__endasm;


#define GET_32BYTES \
    GET_8BYTES \
    GET_8BYTES \
    GET_8BYTES \
    GET_8BYTES

void osc_get_data(void)
{
  char delta = 0;

  /*
   * cycles = 2 + 2 + 1 + (1 + 2) * (delay - 1) + 1 + 1 + 2 = 6 + 3 * delay
   * delay = (cycles - 6) / 3
   * cycles = (scale / 25.6) * 12 MHz
   * delay = (scale * 468750 - 6) / 3 = 156250 * scale - 2
   * scale = (delay + 2) / 156250
   */

  delayhi = 1;

  switch(timescale)
  {
    case 0:  delay = 1;                 break; /*   5 uS/div (4.20  uS/div) */
    case 1:  delay = 1;                 break; /*  10 uS/div (10.6  uS/div) */
    case 2:  delay = 1;                 break; /*  20 uS/div (19.2  uS/div) */
    case 3:  delay = 6;                 break; /*  50 uS/div (51.2  uS/div) */
    case 4:  delay = 13;                break; /* 0.1 mS/div (0.096 mS/div) */
    case 5:  delay = 29;                break; /* 0.2 mS/div (0.198 mS/div) */
    case 6:  delay = 76;                break; /* 0.5 mS/div (0.499 mS/div) */
    case 7:  delay = 154;               break; /*   1 mS/div (0.998 mS/div) */
    case 8:  delay = 154; delayhi = 2;  break; /*   2 mS/div (1.99  ms/div) */
    case 9:  delay = 154; delayhi = 5;  break; /*   5 mS/div (4.99  ms/div) */
    case 10: delay = 154; delayhi = 10; break; /*  10 mS/div (9.99  ms/div) */
    default: delay = 154; delayhi = 20; break; /*  20 mS/div (19.9  ms/div) */
  }

  cnt = 0;

  if(sync == 128) goto got_sync;
  {
    if(sync < 128)
    {
      /* wait for value > sync */
      __asm _osc_sync01:		MOVF	_PORTB, W		__endasm;
      __asm			SUBWF	_sync, W, B		__endasm; /* sync - PORTB */
      __asm			BNC	_osc_sync04		__endasm;
      __asm			MOVFF	_delayhi, _cnt3		__endasm; /* 2 c */
      __asm _osc_sync02:		MOVFF	_delay, _cnt2		__endasm; /* 2 c */
      __asm _osc_sync03:		DECFSZ	_cnt2, F, B 		__endasm; /* 1 c */
      __asm			BRA	_osc_sync03		__endasm; /* 2 c */
      __asm			DECFSZ	_cnt3, F, B 		__endasm; /* 1 c */
      __asm			BRA	_osc_sync02		__endasm; /* 2 c */
      __asm			DECFSZ	_cnt, F, B 		__endasm; /* 1 c */
      __asm			BRA	_osc_sync01 		__endasm; /* 2 c */

      /* wait for value < sync */
      __asm _osc_sync04:		MOVF	_PORTB, W		__endasm;
      __asm			SUBWF	_sync, W, B		__endasm; /* sync - PORTB */
      __asm			BC	_osc_sync07		__endasm;
      __asm			MOVFF	_delayhi, _cnt3		__endasm; /* 2 c */
      __asm _osc_sync05:		MOVFF	_delay, _cnt2		__endasm; /* 2 c */
      __asm _osc_sync06:		DECFSZ	_cnt2, F, B 		__endasm; /* 1 c */
      __asm			BRA	_osc_sync06		__endasm; /* 2 c */
      __asm			DECFSZ	_cnt3, F, B 		__endasm; /* 1 c */
      __asm			BRA	_osc_sync05		__endasm; /* 2 c */
      __asm			DECFSZ	_cnt, F, B 		__endasm; /* 1 c */
      __asm			BRA	_osc_sync04 		__endasm; /* 2 c */
      __asm _osc_sync07:						__endasm;
    }
    else
    {
      /* wait for value < sync */
      __asm _osc_sync11:		MOVF	_PORTB, W		__endasm;
      __asm			SUBWF	_sync, W, B		__endasm; /* sync - PORTB */
      __asm			BC	_osc_sync14		__endasm;
      __asm			MOVFF	_delayhi, _cnt3		__endasm; /* 2 c */
      __asm _osc_sync12:		MOVFF	_delay, _cnt2		__endasm; /* 2 c */
      __asm _osc_sync13:		DECFSZ	_cnt2, F, B 		__endasm; /* 1 c */
      __asm			BRA	_osc_sync13		__endasm; /* 2 c */
      __asm			DECFSZ	_cnt3, F, B 		__endasm; /* 1 c */
      __asm			BRA	_osc_sync12		__endasm; /* 2 c */
      __asm			DECFSZ	_cnt, F, B 		__endasm; /* 1 c */
      __asm			BRA	_osc_sync11 		__endasm; /* 2 c */

      /* wait for value > sync */
      __asm _osc_sync14:		MOVF	_PORTB, W		__endasm;
      __asm			SUBWF	_sync, W, B		__endasm; /* sync - PORTB */
      __asm			BNC	_osc_sync17		__endasm;
      __asm			MOVFF	_delayhi, _cnt3		__endasm; /* 2 c */
      __asm _osc_sync15:		MOVFF	_delay, _cnt2		__endasm; /* 2 c */
      __asm _osc_sync16:		DECFSZ	_cnt2, F, B 		__endasm; /* 1 c */
      __asm			BRA	_osc_sync16		__endasm; /* 2 c */
      __asm			DECFSZ	_cnt3, F, B 		__endasm; /* 1 c */
      __asm			BRA	_osc_sync15		__endasm; /* 2 c */
      __asm			DECFSZ	_cnt, F, B 		__endasm; /* 1 c */
      __asm			BRA	_osc_sync14 		__endasm; /* 2 c */
      __asm _osc_sync17:						__endasm;
    }
  }

got_sync:;

  cnt = 0;

  switch(timescale)
  {
    case 0: /* 2 cycles, 6 Ms/Sec, 4.2 uS/div */
      __asm			LFSR	0, _osc_data 		__endasm;
      GET_32BYTES
      GET_32BYTES
      GET_32BYTES
      GET_32BYTES
      GET_32BYTES
      GET_32BYTES
      GET_32BYTES
      GET_32BYTES
      break;

    case 1:
      /* 5 cycles, 2.4 Ms/sec, 10.6 uS/div */
      __asm 			LFSR	0, _osc_data 		__endasm;
      __asm _osc_get_data1:	MOVFF	_PORTB, _POSTINC0 	__endasm; /* 2 c */
      __asm 			DECFSZ	_cnt, F, B 		__endasm; /* 1 c */
      __asm 			BRA	_osc_get_data1 		__endasm; /* 2 c */
      break;

    case 2:
    case 3:
    case 4:
    case 5:
    case 6:
    case 7:
      /* 9 cycles, 1.3 Ms/sec, 19.2 uS/div */
      __asm 			LFSR	0, _osc_data 		__endasm;
      __asm _osc_get_data3:	MOVFF	_PORTB, _POSTINC0 	__endasm; /* 2 c */

      __asm			MOVFF	_delay, _cnt2		__endasm; /* 2 c */
      __asm _osc_get_data4:	DECFSZ	_cnt2, F, B 		__endasm; /* 1 c */
      __asm 			BRA	_osc_get_data4 		__endasm; /* 2 c */

      __asm 			DECFSZ	_cnt, F, B 		__endasm; /* 1 c */
      __asm 			BRA	_osc_get_data3 		__endasm; /* 2 c */
      break;

    default:
      __asm 			LFSR	0, _osc_data 		__endasm;
      __asm _osc_get_data5:	MOVFF	_PORTB, _POSTINC0 	__endasm; /* 2 c */

      __asm			MOVFF	_delayhi, _cnt3		__endasm; /* 2 c */

      __asm _osc_get_data6:	MOVFF	_delay, _cnt2		__endasm; /* 2 c */
      __asm _osc_get_data7:	DECFSZ	_cnt2, F, B 		__endasm; /* 1 c */
      __asm 			BRA	_osc_get_data7 		__endasm; /* 2 c */

      __asm 			DECFSZ	_cnt3, F, B 		__endasm; /* 1 c */
      __asm 			BRA	_osc_get_data6 		__endasm; /* 2 c */

      __asm 			DECFSZ	_cnt, F, B 		__endasm; /* 1 c */
      __asm 			BRA	_osc_get_data5 		__endasm; /* 2 c */
      break;
  }
}

void SetSensitivity()
{	//			8 4	2 1		8 4 2 1
	// PORTA RA{7 6 5 4 	3 2 1 0}
	//			* * *	  	  *		// used. 2
	//		 3b{* *   0 	0 * 1 1}
	
	switch(sens)
	{
		case 1:
			//1
			PORTA = 0x2E;
			break;
		case 2:
			//2
			PORTA = 0x24;
			break;
		case 3:
			//5
			PORTA = 0x26;
			break;
		case 4:
			//10
			PORTA = 0x2C;
			break;
		case 5:
			//20
			PORTA = 0x27;
			break;
		case 6:
			//50
			PORTA = 0x25;
			break;
		case 9:
			//GND
			PORTA = 0x2F;
		default:
			break;
	}
}

void SetShutt()
{
	switch(shutt)
	{
		case 0:
			PORTC &=~(1<<0); // Сбросим в 0 первый бит.
			break;
		case 1:
			PORTC |= 1<<0;   // Установим в 1 первый бит.
			break;
		default:
			break;
	}
}

void SetDiv100()
{
	
	switch(div100)
	{
		case 0:
			//0
			PORTC &=~(1<<1); // Сбросим в 0 второй бит.
			break;
		case 1:
			//1
			PORTC |= 1<<1; // Установим в 1 второй бит.
			break;
		default:
			break;
	}
	
}

void OscService(void)
{ byte i=0, part;

    if((usb_device_state < CONFIGURED_STATE) || (UCONbits.SUSPND)) return;

    if(!(ep1Bo.Stat & _USIE))
    { // Команда получена, нужно обработать
        switch(dataOUT[0])
        {
            case READ_VERSION:
		        i = 2;
		        dataIN[0] = MINOR_VERSION;
				dataIN[1] = MAJOR_VERSION;
				break;

			case COLLECT_OSC_DATA:
				i = 1;
				osc_get_data();
				dataIN[0] = 1;
				break;

            case READ_OSC_DATA:
				part = dataOUT[1] * 64;
				for(i = 0; i < 64; i++, part++)
				{
					dataIN[i] = osc_data[part];
				}
                i = 64;
		    	break;

		    case SET_OFFSET:
				CVRCON = 0xC0 | (dataOUT[1] & 0x0F);
				i = 0;
				break;

		    case SET_TIMESCALE:
				timescale = dataOUT[1];
				i = 0;
				break;

		    case SET_SYNC:
				sync = dataOUT[1];
				i = 0;
				break;

			case SET_SENS:
				sens = dataOUT[1];
				SetSensitivity();
				i=0;
				break;
			case SET_SHUTTER:
				shutt = dataOUT[1];
				SetShutt();
				break;
			case SET_DIVIDER:
				div100 = dataOUT[1];
				SetDiv100();
				break;
		    default:
		        i = 0;
			    break;
        }
	
        if(i != 0)
        { // Передать запрошенные данные
            ep1Bi.Cnt = i;

	    if(ep1Bi.Stat & _DTSMASK)
	        ep1Bi.Stat = _USIE | _DAT0 | _DTSEN;
            else
	        ep1Bi.Stat = _USIE | _DAT1 | _DTSEN;
        }

        // Принять следующую команду
        ep1Bo.Cnt = sizeof(dataOUT);

        if(ep1Bo.Stat & _DTSMASK)
            ep1Bo.Stat = _USIE | _DAT0 | _DTSEN;
        else
            ep1Bo.Stat = _USIE | _DAT1 | _DTSEN;

    }
}

void USBUserInit()
{
    UEP1 = EP_OUT_IN | HSHK_EN;           // Enable 2 data pipes

    ep1Bo.Cnt  = OSC_EP_SIZE;              // buffer size
    ep1Bo.ADR  = (__data byte*)&dataOUT;   // buffer address
    ep1Bo.Stat = _USIE | _DAT0 | _DTSEN;  // status

    ep1Bi.ADR  = (__data byte*)&dataIN;     // buffer address
    ep1Bi.Stat = _UCPU | _DAT1;           // status
}

void main(void)
{
    /* Настроить порты */

    /*
     * RA0 -> Sensitivity
     * RA1 -> Sensitivity
     * RA2 <- A-> CVref
     * RA3 -> Sensitivity
	 
     * RA4 -> ???
     * RA5 -> USB_OK LED 
	 * RA6 = XTAL
	 * RA7 = XTAL
     */
    PORTA = 0x20;
    TRISA = 0x04; //0x0F;

    CMCON = 0x07;
    CVRCON = 0xE7;

    ADCON1 = 0x0F;

    /*
     * RB0-RB7 <- ADC data
     */
    PORTB = 0;
    TRISB = 0xFF;

    /*
     * RC0 -> Shutter
     * RC1 -> Divider(100)
     * RC2 -> CCP1 PWM (ADC Clk)
	 * RC3 <- \
	 * RC4 <-  -- used
	 * RC5 <- /
     * RC6 -> ???
     * RC7 -> ???
     */
    PORTC = 0xFC;
    TRISC = 0x38;

    /* Включить таймер (16 бит, CLK 3 Мгц (48 МГц / 4 / 4)) */
//    T0CON = 0x81;
//    INTCONbits.TMR0IF = 0;

    /* ADC clock. PWM1 module. 12MHz output. High on Q1 cycle only */
    CCP1CON = 0x1F;
    CCPR1L  = 0x00;
    PR2     = 0x00;
    TMR2    = 0;
    /* Включить Timer2 - post: 1:1, pre: 1:1 */
    T2CON = 0x04;

    timescale = 1;    

//    p_count   = 0;
//    p_delay.w = -250; /* 3 000 000 Hz / 12 000 pps = 250 */

//    TMR0H = p_delay.h;
//    TMR0L = p_delay.l;
    

    /* Включить USB */
    USBInit();

//    PIE2bits.USBIE = 1;            /* разрешить прерывания USB */
//    INTCON = 0xC0;                 /* разрешить прерывания */

    while(1)
    {
        USBIntService();
        OscService();
    }
}
