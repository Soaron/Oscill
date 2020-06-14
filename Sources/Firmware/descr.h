#ifndef _DESCR_H
#define _DESCR_H

/******************************************************************************
 * USB Device Descriptor Structure
 *****************************************************************************/
typedef struct _USB_DEV_DSC
{
    byte bLength;
    byte bDscType;
    word bcdUSB;
    byte bDevCls;
    byte bDevSubCls;
    byte bDevProtocol;
    byte bMaxPktSize0;
    word idVendor;
    word idProduct;
    word bcdDevice;
    byte iMFR;
    byte iProduct;
    byte iSerialNum;
    byte bNumCfg;
} USB_DEV_DSC;

/******************************************************************************
 * USB Configuration Descriptor Structure
 *****************************************************************************/
typedef struct _USB_CFG_DSC
{
    byte bLength;
    byte bDscType;
    word wTotalLength;
    byte bNumIntf;
    byte bCfgValue;
    byte iCfg;
    byte bmAttributes;
    byte bMaxPower;
} USB_CFG_DSC;

/******************************************************************************
 * USB Interface Descriptor Structure
 *****************************************************************************/
typedef struct _USB_INTF_DSC
{
    byte bLength;
    byte bDscType;
    byte bIntfNum;
    byte bAltSetting;
    byte bNumEPs;
    byte bIntfCls;
    byte bIntfSubCls;
    byte bIntfProtocol;
    byte iIntf;
} USB_INTF_DSC;

/******************************************************************************
 * USB Endpoint Descriptor Structure
 *****************************************************************************/
typedef struct _USB_EP_DSC
{
    byte bLength;
    byte bDscType;
    byte bEPAdr;
    byte bmAttributes;
    word wMaxPktSize;
    byte bInterval;
} USB_EP_DSC;


typedef struct _USB_CONFIGURATION
{   USB_CFG_DSC             cd01;
    USB_INTF_DSC            i00a00;
    USB_EP_DSC              ep01o_i00a00;
    USB_EP_DSC              ep01i_i00a00;
} USB_CONFIGURATION;

extern const USB_DEV_DSC device_dsc;
extern const USB_CONFIGURATION cfg01;

typedef struct { byte l; byte t; word s[1]; } __sd000_t;
typedef struct { byte l; byte t; word s[21]; } __sd001_t;
typedef struct { byte l; byte t; word s[16]; } __sd002_t;
typedef struct { byte l; byte t; word s[5]; } __sd003_t;

extern const __sd000_t sd000;
extern const __sd001_t sd001;
extern const __sd002_t sd002;
extern const __sd003_t sd003;

#endif

