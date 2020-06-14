#ifndef _MAIN_H
#define _MAIN_H

/* Oscilloscope Version */
#define MINOR_VERSION   0x03    //Oscilloscope Version 1.03
#define MAJOR_VERSION   0x01

#define OSC_EP_SIZE		64

/* Oscilloscope commands */
#define READ_VERSION		0
#define COLLECT_OSC_DATA	1
#define READ_OSC_DATA		2
#define SET_OFFSET			3
#define SET_TIMESCALE		4
#define SET_SYNC			5
#define SET_SENS			6
#define SET_SHUTTER			7
#define SET_DIVIDER			8

#endif
