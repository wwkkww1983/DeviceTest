/**********************************************************************\
**
**                         Copyright (c) 2007-2015 by
**                          HENGSTLER GmbH, Aldingen
**
**      This  software  is furnished under a license and may be used and
**      copied only in accordance with the terms  of  such  license  and
**      with the inclusion of the above copyright notice.  This software
**      or any other copies thereof may not  be  provided  or  otherwise
**      made  available  to any other person.  No title to and ownership
**      of the software is hereby transferred.
**
**      The  information  in  this software is subject to change without
**      notice and should not be construed as a commitment by Hengstler.
**
**  Module:      Exo_PrintMonPlugin.h
**  Facility:    S684015 - Hengstler Extendo Printer Driver for Windows XP/7/8
**  Component:   Print Monitor Plugin (Exo-PrintMonPlugin)
**  Version:     R5-V2.01-FINAL / 2015MAY07
**  Environment: Windows XP/7/8 
**  Compiler:    Microsoft Visual C++ .NET   69462-005-9462412-18296
**  Abstract:    Definitions of print monitor plugin interface and registry entries
**  Note:        -
**  History:     R1-V1.00 / 2007DEC21 / HOR / 1ST RELEASE 
**               -----------------------------------------------------
**               R2-V1.01 / 2008MAY31 / HOR / 2ND RELEASE 
**               -----------------------------------------------------
**               R3-V1.02 / 2010APR30 / HOR / 3RD RELEASE
**               -----------------------------------------------------
**               R4-V2.00a / 2011MAY26 / HOR / M-R4-004-HOR
**                  Complete printer package ported to VS2010, reviewed and adapted Windows 7 32+64 bit
**               R4-V2.00 / 2013JUL18 / HOR / 4TH RELEASE
**               -----------------------------------------------------
**               R5-V2.01 / 2015MAY07 / HOR / 5TH RELEASE
**               -----------------------------------------------------
**
\**********************************************************************/

/*
** COMPILER
*/

#pragma once

/*
** INCLUDES
*/ 


#include "..\..\Libraries\Exo_Api.h"
/*
** MACROS
*/ 

//-- Windows registry key in printer data where print monitor plugin info is stored
#define D_EXO_PMP_REG_KEY                        "EXTENDO-DRIVER"

//-- Windows registry value for corresponding print monitor plugin info
#define D_EXO_PMP_REG_VALUE_PMP_PRINTER_INFO     "EXTENDO-PMP-PRINTER-INFO"
#define D_EXO_PMP_REG_VALUE_PMP_PRINTER_STATUS   "EXTENDO-PMP-PRINTER-STATUS"
#define D_EXO_PMP_REG_VALUE_PMP_PRINTER_SENSOR   "EXTENDO-PMP-PRINTER-SENSOR"
#define D_EXO_PMP_REG_VALUE_PMP_JOB_INFO         "EXTENDO-PMP-JOB-INFO"
#define D_EXO_PMP_REG_VALUE_PMP_SETTINGS         "EXTENDO-PMP-SETTINGS"

/*
** TYPES
*/ 
   
//********************************************************************************************************
//** TYPE:        TS_EXO_PMP_JOB_INFO
//** ABSTRACT:    Type definition for print monitor plugin structure containing job information 
//********************************************************************************************************

#pragma pack(1)
typedef struct
   { DWORD                         dwSize;                // Size of this structure
     unsigned char                 ubRevision;            // Revision number (D_EXO_PMP_JI_REVISION)
     DWORD                         dwTsLastUpdate;        // Timestamp of last structure update (from GetTickCount)
     DWORD                         dwJobId;               // Identifier of current/last job (-1 indicates no job)
     DWORD                         dwJobStatus;           // Job status (see D_EXO_PMP_JI_JS_...) (if dwJobId != -1)
     DWORD                         dwPageCount;           // Number of pages printed (if dwJobId != -1)
     BYTE                          aubReserved[32];       // Reserved bytes for future use
   } TS_EXO_PMP_JOB_INFO, * PS_EXO_PMP_JOB_INFO;          // Print monitor plugin job information 
#define D_EXO_PMP_JI_REVISION                    0        // Structure revision number for TS_EXO_PMP_JOB_INFO
#define D_EXO_PMP_JI_JS_JOB_ACTIVE               0x0001   // Job status in TS_EXO_PMP_JOB_INFO->dwJobStatus
#define D_EXO_PMP_JI_JS_JOB_FINISHED             0x0002   // Job status in TS_EXO_PMP_JOB_INFO->dwJobStatus
#define D_EXO_PMP_JI_JS_JOB_CANCELLED            0x0003   // Job status in TS_EXO_PMP_JOB_INFO->dwJobStatus
#pragma pack()

//********************************************************************************************************
//** TYPE:        TS_EXO_PMP_PRINTER_STATUS
//** ABSTRACT:    Type definition for print monitor plugin structure containing status information 
//********************************************************************************************************

#pragma pack(1)
typedef struct
   { DWORD                          dwSize;                // Size of this structure
     unsigned char                  ubRevision;            // Revision number (D_EXO_PMP_PST_REVISION)
     DWORD                          dwTsLastUpdate;        // Timestamp of last structure update (from GetTickCount)
     DWORD                          dwDataValidFlag;       // Data valid flags (see D_EXO_PMP_PST_DVF_...)
     TS_EXO_API_PCKT_PRINTER_STATUS sPrinterStatus;        // Printer status (command: GS a+[n],n=0x00)
     BYTE                           aubReserved[32];       // Reserved bytes for future use
   } TS_EXO_PMP_PRINTER_STATUS, * PS_EXO_PMP_PRINTER_STATUS; // Print monitor plugin printer status 
#define D_EXO_PMP_PST_REVISION                    0        // Structure revision number for TS_EXO_PMP_PRINTER_STATUS
#define D_EXO_PMP_PST_DVF_PRINTER_STATUS          0x0001   // Valid flag, bit offset in TS_EXO_PMP_PRINTER_STATUS->dwDataValidFlag
#pragma pack()

//********************************************************************************************************
//** TYPE:        TS_EXO_PMP_PRINTER_INFO
//** ABSTRACT:    Type definition for print monitor plugin structure containing printer information 
//********************************************************************************************************

#pragma pack(1)
typedef struct
   { DWORD                          dwSize;                // Size of this structure
     unsigned char                  ubRevision;            // Revision number (D_EXO_PMP_PI_REVISION)
     DWORD                          dwTsLastUpdate;        // Timestamp of last structure update (from GetTickCount)
     DWORD                          dwDataValidFlag;       // Data valid flags (see D_EXO_PMP_PI_DVF_...)
     TS_EXO_API_PCKT_PRINTER_INFO   sPrinterInfo;          // Printer info (command: GS a+[n],n=0x01)
     BYTE                           aubReserved[32];       // Reserved bytes for future use
   } TS_EXO_PMP_PRINTER_INFO, * PS_EXO_PMP_PRINTER_INFO;   // Print monitor plugin printer info 
#define D_EXO_PMP_PI_REVISION                    1         // Structure revision number for TS_EXO_PMP_PRINTER_INFO
#define D_EXO_PMP_PI_DVF_PRINTER_INFO            0x0001    // Valid flag, bit offset in TS_EXO_PMP_PRINTER_INFO->dwDataValidFlag
#pragma pack()

//********************************************************************************************************
//** TYPE:        TS_EXO_PMP_PRINTER_SENSOR
//** ABSTRACT:    Type definition for print monitor plugin structure containing sensor information 
//********************************************************************************************************

#pragma pack(1)
typedef struct
   { DWORD                          dwSize;                // Size of this structure
     unsigned char                  ubRevision;            // Revision number (D_EXO_PMP_PSE_REVISION)
     DWORD                          dwTsLastUpdate;        // Timestamp of last structure update (from GetTickCount)
     DWORD                          dwDataValidFlag;       // Data valid flags (see D_EXO_PMP_PSE_DVF_...)
     TS_EXO_API_PCKT_PRINTER_SENSOR sPrinterSensor;        // Printer sensor (command: GS a+[n],n=0x02)
     BYTE                           aubReserved[32];       // Reserved bytes for future use
   } TS_EXO_PMP_PRINTER_SENSOR, * PS_EXO_PMP_PRINTER_SENSOR;  // Print monitor plugin printer sensor
#define D_EXO_PMP_PSE_REVISION                    0        // Structure revision number for TS_EXO_PMP_PRINTER_SENSOR
#define D_EXO_PMP_PSE_DVF_PRINTER_SENSOR          0x0001   // Valid flag, bit offset in TS_EXO_PMP_PRINTER_SENSOR->dwDataValidFlag
#pragma pack()

//********************************************************************************************************
//** TYPE:        TS_EXO_PMP_SETTINGS
//** ABSTRACT:    Type definition for print monitor plugin structure containing settings for the plugin 
//********************************************************************************************************

#pragma pack(1)
typedef struct
   { DWORD                         dwSize;                 // Size of this structure
     unsigned char                 ubRevision;             // Revision number (D_EXO_PMP_SE_REVISION)
     WORD                          wServiceIntervalSec;    // Service interval in sec (30 by default, 0 is disable, 5 is minimum)
     WORD                          wMaxDurationOfPrintSec; // Maximum duration of a single page printout until it is cancelled
     WORD                          wDelayInquiryStartMs;   // Delay at start of inquiry in MS, set to 50 if zero, domain [1..1000]
     WORD                          wDelayInquiryResponseMs;// Delay during inquiry (between write and read) in MS, set to 150 if zero, domain [1..1000]
     WORD                          wDelayInquiryEndMs;     // Delay at end of inquiry in MS, set to 50 if zero, domain [1..1000]
     WORD                          wOptions;               // Plugin option bitmask (see D_EXO_PMP_SE_OPT_INQ_...)
     BYTE                          aubReserved[32];        // Reserved bytes for future use
   } TS_EXO_PMP_SETTINGS, * PS_EXO_PMP_SETTINGS;           // Print monitor plugin settings
#define D_EXO_PMP_SE_REVISION                 1            // Structure revision number for TS_EXO_PMP_SETTINGS
#define D_EXO_PMP_SE_OPT_UPDATE_PRINTER_INFO_AT_END_OF_DOC_DISABLED    0x0001   // Option, disables printer info   inquiry at end of document
#define D_EXO_PMP_SE_OPT_UPDATE_PRINTER_STATUS_AT_END_OF_DOC_DISABLED  0x0002   // Option, disables printer status inquiry at end of document
#define D_EXO_PMP_SE_OPT_UPDATE_PRINTER_SENSOR_AT_END_OF_DOC_DISABLED  0x0004   // Option, disables printer status inquiry at end of document
#define D_EXO_PMP_SE_OPT_UPDATE_PRINTER_INFO_DURING_SERVICE_DISABLED   0x0008   // Option, disables printer info   inquiry at end of document
#define D_EXO_PMP_SE_OPT_UPDATE_PRINTER_STATUS_DURING_SERVICE_DISABLED 0x0010   // Option, disables printer status inquiry at end of document
#define D_EXO_PMP_SE_OPT_UPDATE_PRINTER_SENSOR_DURING_SERVICE_DISABLED 0x0020   // Option, disables printer status inquiry at end of document
#pragma pack()

/*
** FUNCTIONS
*/ 

//********************************************************************************************************
//** TYPE:        Exo_Pmp_StartMonitor 
//** ABSTRACT:    Type definition for the print monitor plugin function that is called at start of print monitoring
//**              The function must initialize the plugin dll
//**              The function is called after port has been opened 
//** PARAMETER:   pszPortName           Name of the port
//**              pszPrinterName        Name of the printer
//**              hPmCallback           Handle for port monitor callback (read/write port)
//**              pdwServiceIntervalSec Required service interval in sec (min 30, disabled 0)
//**              pfnWritePort          Callback function for writing data to port
//**              pfnReadPort           Callback function for reading data from port
//** RETURN:      hData                 Handle pointing to private plugin data (used in other TF_Exo_Pmp_... functions)
//** NOTE:        The plugin function is called if available in Exo_PrintMonPlugin.dll
//********************************************************************************************************

typedef HANDLE (* TF_Exo_Pmp_StartMonitor) ( LPTSTR pszPortName, LPTSTR pszPrinterName
                                          , HANDLE hPmCallback, DWORD * pdwServiceIntervalSec
                                          , BOOL (*pfnWritePort) (HANDLE, LPBYTE, DWORD, LPDWORD, DWORD)
                                          , BOOL (*pfnReadPort)  (HANDLE, LPBYTE, DWORD, LPDWORD, DWORD));

//********************************************************************************************************
//** TYPE:        Exo_Pmp_EndMonitor 
//** ABSTRACT:    Type definition for the print monitor plugin function that is called at end of print monitoring 
//**              The function must free all allocated memory
//**              The function is called just before port closes 
//** PARAMETER:   hData                 Handle pointing to private plugin data (from TF_Exo_Pmp_StartMonitor)
//** RETURN:      fResult               Flag indicating success if TRUE and FALSE otherwise
//** NOTE:        The plugin function is called if available in Exo_PrintMonPlugin.dll
//********************************************************************************************************

typedef BOOL (* TF_Exo_Pmp_EndMonitor)    (HANDLE hData);

//********************************************************************************************************
//** TYPE:        Exo_Pmp_StartDocument 
//**              Exo_Pmp_StartDocument2
//** ABSTRACT:    Type definition for the print monitor plugin function that is called when document printing has started
//** PARAMETER:   hData                 Handle pointing to private plugin data (from TF_Exo_Pmp_StartMonitor)
//**              pszPrinterName        Name of the printer
//**              dwDocInfoLevel        Level of pbDocInfo indicating DOC_INFO_1/2/3 
//**              pbDocInfo             Pointer to DOC_INFO_1/2/3 structure
//**              dwJobId               Id of job that is being done
//**              hPrinter              Handle of printer  (Exo_Pmp_StartDocument2 only)
//** RETURN:      fResult               Flag indicating success if TRUE and FALSE otherwise
//** NOTE:        The plugin function is called if available in Exo_PrintMonPlugin.dll
//********************************************************************************************************

typedef BOOL (* TF_Exo_Pmp_StartDocument)  (HANDLE hData, LPTSTR pszPrinterName, DWORD dwJobId, DWORD dwDocInfoLevel, LPBYTE  pbDocInfo);
typedef BOOL (* TF_Exo_Pmp_StartDocument2) (HANDLE hData, LPTSTR pszPrinterName, DWORD dwJobId, DWORD dwDocInfoLevel, LPBYTE  pbDocInfo, HANDLE hPrinter);

//********************************************************************************************************
//** TYPE:        Exo_Pmp_CancelDocument  
//** ABSTRACT:    Type definition for the print monitor plugin function that is called when document printing has an error
//** PARAMETER:   hData                 Handle pointing to private plugin data (from TF_Exo_Pmp_StartMonitor)
//**              dwDurationOfPrintSec  Number of seconds elapsed since the printout of the page has been started
//** RETURN:      fResult               Flag indicating continue print if FALSE and cancel print otherwise
//** NOTE:        The plugin function is called if available in Exo_PrintMonPlugin.dll
//********************************************************************************************************

typedef BOOL (* TF_Exo_Pmp_CancelDocument) (HANDLE hData, DWORD dwDurationOfPrintSec);

//********************************************************************************************************
//** TYPE:        Exo_Pmp_EndDocument  
//** ABSTRACT:    Type definition for the print monitor plugin function that is called before document printing has ended 
//** PARAMETER:   hData                 Handle pointing to private plugin data (from TF_Exo_Pmp_StartMonitor)
//** RETURN:      fResult               Flag indicating success if TRUE and FALSE otherwise
//** NOTE:        The plugin function is called if available in Exo_PrintMonPlugin.dll
//********************************************************************************************************

typedef BOOL (* TF_Exo_Pmp_EndDocument) (HANDLE hData);

//********************************************************************************************************
//** TYPE:        Exo_Pmp_StartPage  
//** ABSTRACT:    Type definition for the print monitor plugin function that is called before page printing has started
//** PARAMETER:   hData                 Handle pointing to private plugin data (from TF_Exo_Pmp_StartMonitor)
//** RETURN:      fResult               Flag indicating success if TRUE and FALSE otherwise
//** NOTE:        The plugin function is called if available in Exo_PrintMonPlugin.dll
//********************************************************************************************************

typedef BOOL (* TF_Exo_Pmp_StartPage) (HANDLE hData);

//********************************************************************************************************
//** TYPE:        Exo_Pmp_EndPage  
//** ABSTRACT:    Type definition for the print monitor plugin function that is called before page printing has completed
//** PARAMETER:   hData                 Handle pointing to private plugin data (from TF_Exo_Pmp_StartMonitor)
//** RETURN:      fResult               Flag indicating success if TRUE and FALSE otherwise
//** NOTE:        The plugin function is called if available in Exo_PrintMonPlugin.dll
//********************************************************************************************************

typedef BOOL (* TF_Exo_Pmp_EndPage) (HANDLE hData);

//********************************************************************************************************
//** TYPE:        Exo_Pmp_ServiceRoutine
//** ABSTRACT:    Type definition for the print monitor plugin function that services periodical calls
//** PARAMETER:   hData                 Handle pointing to private plugin data (from TF_Exo_Pmp_StartMonitor)
//** RETURN:      fResult               Flag indicating success if TRUE and FALSE otherwise
//** NOTE:        The plugin function is called if available in Exo_PrintMonPlugin.dll
//********************************************************************************************************

typedef BOOL (* TF_Exo_Pmp_ServiceRoutine) (HANDLE hData);

/*
** VARIABLES
*/ 
