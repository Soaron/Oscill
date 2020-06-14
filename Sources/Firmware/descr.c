/***************************************************************************
 *   Copyright (C) 2009 by Stanson <stanson@pangolin.ru>                   *
 *   GPL v3 code, read COPYING file                                        *
 **************************************************************************/
#include "usb.h"
#include "descr.h"
#include "main.h"

/* Device Descriptor */
const USB_DEV_DSC device_dsc = 
{
    sizeof(USB_DEV_DSC),    // Size of this descriptor in bytes
    DSC_DEV,                // DEVICE descriptor type
    0x0200,                 // USB Spec Release Number in BCD format
    0x00,                   // Class Code
    0x00,                   // Subclass code
    0x00,                   // Protocol code
    EP0_BUFF_SIZE,          // Max packet size for EP0, see usbcfg.h
    0x04d8,					// VendorID
    0x0002,					// ProductID
    0x0102,                 // Device release number in BCD format
    0x01,                   // Manufacturer string index
    0x02,                   // Product string index
    0x03,                   // Device serial number string index
    0x01                    // Number of possible configurations
};

/* Configuration Descriptor */
const USB_CONFIGURATION cfg01 =
{
    {
        sizeof(USB_CFG_DSC),      // Size of this descriptor in bytes
        DSC_CFG,                  // CONFIGURATION descriptor type
        sizeof(cfg01),            // Total length of data for this cfg
        1,                        // Number of interfaces in this cfg
        1,                        // Index value of this configuration
        0,                        // Configuration string index
        _DEFAULT,                 // Attributes, see usbdefs_std_dsc.h
        250                       // Max power consumption (2X mA)
    },
    /* Interface Descriptor */
    {
        sizeof(USB_INTF_DSC),   // Size of this descriptor in bytes
        DSC_INTF,               // INTERFACE descriptor type
        0,                      // Interface Number
        0,                      // Alternate Setting Number
        2,                      // Number of endpoints in this intf
        0x00,                   // Class code
        0x00,                   // Subclass code
        0x00,                   // Protocol code
        0                       // Interface string index
    },
    /* Endpoint Descriptors */
    { sizeof(USB_EP_DSC), DSC_EP, _EP01_OUT, _BULK, OSC_EP_SIZE, 0x00 },
    { sizeof(USB_EP_DSC), DSC_EP, _EP01_IN,  _BULK, OSC_EP_SIZE, 0x00 }
};
/* String Descriptors */
const __sd000_t sd000 = 
{
    sizeof(sd000),
    DSC_STR,
    { 0x0409 }
};

const __sd001_t sd001 = 
{
    sizeof(sd001),
    DSC_STR,
    { 'I','l','l','e','g','a','l',' ','S','y','s','t','e','m','s',' ','C','o','r','p','.' }
};

const __sd002_t sd002 = 
{
    sizeof(sd002),
    DSC_STR,
    { 'I','S','C',' ','O','s','c','i','l','l','o','s','c','o','p','e' }
};

const __sd003_t sd003 = 
{
    sizeof(sd003),
    DSC_STR,
    { 'V','1','.','0','3' }
};

