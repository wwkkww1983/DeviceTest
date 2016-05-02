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
**  Module:      Exo_Api.h
**  Facility:    S684015 - Hengstler Extendo Printer Driver for Windows XP/7/8
**  Component:   Exo_Api (Application Programming Interface)
**  Version:     R5-V2.01-FINAL / 2015MAY07
**  Environment: Windows XP/7/8 
**  Compiler:    Microsoft Visual 2010 C++ .NET   
**  Abstract:    Application programming interface of extendo printer driver
**  History:     R1-V1.00 / 2007DEC21 / HOR / 1ST RELEASE 
**               -----------------------------------------------------
**               R2-V1.01  / 2008MAY08 / HOR / M-R2-008-HOR 
**                  Wrong value for packet identifier D_EXO_API_PID_TX_PRINTER_FLASH changed to 0x05.
**               R2-V1.01  / 2008MAY31 / HOR / 2ND RELEASE
**               R2-V1.01 / 2008MAY31 / HOR / 2ND RELEASE 
**               -----------------------------------------------------
**               R3-V1.02a / 2008AUG15 / HOR / R3-008-HOR
**                  The error DWORD in structure TS_EXO_API_PCKT_PRINTER_STATUS 
**                  is extended with error information regarding the presenter unit.
**               R3-V1.02a / 2008AUG19 / HOR / R3-011-HOR
**                  New presenter status packet TS_API_PCKT_PRESENTER_STATUS added.
**               R3-V1.02a / 2009MAR09 / HOR / R3-013-HOR
**                  Printer status DWORD in packet TS_EXO_API_PCKT_PRINTER_STATUS extended with D_EXO_API_PRINTER_STATUS_PSDW_EEPROM_MISSING.
**               R3-V1.02  / 2010APR29 / HOR / R3-028-HOR
**                  Printer status DWORD in packet TS_EXO_API_PCKT_PRINTER_STATUS extended with D_EXO_API_PRINTER_STATUS_PSDW_PARCUT... flags.
**               R3-V1.02 / 2010APR30 / HOR / 3RD RELEASE
**               -----------------------------------------------------
**               R4-V2.00a  / 2011MAY26 / HOR / M-R4-004-HOR
**                  Complete printer package ported to VS2010, reviewed and adapted Windows 7 32+64 bit
**               R4-V2.00c  / 2011JUL22 / HOR / M-R4-010-HOR
**                  Printer status extended with presenter available and presenter active flag. This new flag is available from firmware version R4-V1.03h.
**               R4-V2.00c  / 2011JUL22 / HOR / M-R4-011-HOR
**                  Presenter status packet adapted to that of firmware version R4-V1.03h.
**               R4-V2.00e  / 2011FEB20 / HOR / M-R4-032-HOR
**                  Configuration data structure moved from Exo-Tb.h to Exo-Api.h
**               R4-V2.00e  / 2011FEB20 / HOR / M-R4-033-HOR
**                  Configuration data option “Automatic Recovery on init?(0x00000400 / D_EXO_CD_ OPTION_ENABLE_AUTOMATIC_RECOVERY_ON_INIT /
**                  D_EXO_CD_OPTION_UNJAM_PAPER_ON_INIT) is no longer available since firmware R4-V2.00e. The printer will automatically 
**                  recover on init if possible.
**               R4-V2.00e  / 2011FEB20 / HOR / M-R4-036-HOR
**                  Option “pre-pull form before print?added to configuration data, which is available since firmware R4-V2.00a.
**               R4-V2.00e  / 2011FEB21 / HOR / M-R4-037-HOR
**                  Speed settings for paper load, paper advance and paper reverse added to configuration data, which are available 
**                  since firmware R4-V2.00a.
**               R4-V2.00e  / 2011MAR12 / HOR / M-R4-039-HOR
**                  Option “use improved burn time determination?added to configuration data, which is available since firmware R4-V2.00a.
**               R4-V2.00e  / 2012APR13 / HOR / M-R4-042-HOR
**                  Sensor readings data package (GS 'a' +[n]) extended with presenter sensor #1 and #2 information.
**               R4-V2.00f  / 2012SEP13 / HOR / M-R4-048-HOR
**                  Review of the presenter status structure.
**               R4-V2.00g  / 2013JAN21 / HOR / M-R4-051-HOR
**                  Configuration data extended with a paper load setting that disables reverse motion when paper load fails. Currently loaded paper is rejected when 
**                  the paper exit sensor remains unoccupied during paper load. This reverse motion without paper could damage the platen, especially when paper is 
**                  frequently loaded, such as in ticket in/out applications. By enabling the “disable paper reject on paper load fail?option, the printer will stop 
**                  the paper load process immediately and will not reject the inserted paper.
**               R4-V2.00g  / 2013JAN21 / HOR / M-R4-052-HOR
**                  Configuration data extended with a presenter setting that disables the auto reject function of the driver. If enabled, then this “disable auto 
**                  presenter reject feature?causes the presenter to wait for the host command before rejecting the ticket.
**               R4-V2.00 / 2013JUL18 / HOR / 4TH RELEASE
**               -----------------------------------------------------
**               R5-V2.01a / 2013OCT25 / HOR / M-R5-001-HOR 
**                  Configuration settings extended with option “DISABLE SCAN OUTSIDE MARK AREA?  If enabled, paper mark detection is limited 
**                  to the defined paper mark area +- 10 mm.
**               R5-V2.01a / 2013NOV12/ HOR / M-R5-003-HOR 
**                  API extended with function Exo_Api_Pio_PrinterPrintImage. This function This function loads a black and white image from a file, 
**                  converts it to emulation commands and sends these commands to the printer. Note that no color to monochrome rendering is done.
**               R5-V2.01b / 2014FEB07/ HOR / M-R5-008-HOR 
**                  Configuration data extended with sensor current adjustment setting. This setting allows a 4 bit current automatic adjustment of the 
**                  paper entry sensor and a 2 bit adjustment of the paper exit (chute) sensor. The adjustment is done during paper load.
**               R5-V2.01b / 2014AUG28 / HOR / M-R5-013-HOR 
**                  Settings for dynamic sensor current adjustment feature added to configuration data.
**               R5-V2.01b / 2014NOV14 / HOR / M-R5-015-HOR 
**                  By default, the automatic sensor adjustment is done during the initial paper load only. This is done to assure best possible backward 
**                  compatibility for application in which a sensor calibration feature is undesired.
**               R5-V2.01b / 2015JAN30 / HOR / M-R5-016-HOR 
**                  Configuration data structure extended with a pre-mark validation distance  (ubPreMarkValidationDistanceTmm),  which defines the minimum 
**                  length of the “white?area that precedes the paper mark. Note that this setting is available from firmware R5-V2.01i.
**               R5-V2.01b / 2015JAN30 / HOR / M-R5-017-HOR 
**                  Configuration data structure extended with a post-mark validation distance (ubPostMarkValidationDistanceTmm), which defines the minimum 
**                  length of the “white?area that  succeeds the paper mark. Note that this setting is available from firmware R5-V2.01i.
**               R5-V2_01b / 2015FEB12 / HOR / M-R5-018-HOR
**                  Configuration data extended with a minimum and maximum dynamic paper entry sensor current adjustment settings. This setting 
**                  assures that, when, for the paper entry sensor, dynamic current adjustment is enabled, the selected current does not get beyond 
**                  the defined minimum / above the defined maximum. A value of 0 for the minimum or maximum dynamic paper enter sensor current 
**                  adjustment selects default values With firmware V2.01i following defaults are used. For reflex sensors, the default minimum / 
**                  maximum current is 11.8 mA / 26.6 mA. For through light sensors, the default minimum / maximum current is 9.6 mA / 26.6 mA.
**               R5-V2.01 / 2015MAY07 / HOR / 5TH RELEASE
**               -----------------------------------------------------
**
\**********************************************************************/

#ifndef __EXO_API_H 
#define __EXO_API_H 

/*
** COMPILER
*/

/*
** INCLUDES
*/

/*
** MACROS 
*/

//-- Extendo printer access options
#define D_EXO_API_PIO_OPT_NONE                                                0x00000000 // Option indicating NO OPTIONS                      
#define D_EXO_API_PIO_OPT_NO_SYNCHRONIZE                                      0x00000001 // Option indicating NO SYNCHRONIZE on connect       

//-- Extendo printer access error codes from GetLastError()
#define D_EXO_API_PIO_ERR_OUTOFMEMORY                                         0x40000001 // Error code indicating out of memory               
#define D_EXO_API_PIO_ERR_STOPSPOOLERFAILED                                   0x40000002 // Error code indicating stop spooler failed         
#define D_EXO_API_PIO_ERR_INVALIDPARAMETER                                    0x40000003 // Error code indicating invalid parameter           
#define D_EXO_API_PIO_ERR_ENDOFENUM                                           0x40000004 // Error code indicating end of enumeration          
#define D_EXO_API_PIO_ERR_OPENPRINTERFAILED                                   0x40000005 // Error code indicating open printer failed         
#define D_EXO_API_PIO_ERR_READPRINTERFAILED                                   0x40000006 // Error code indicating read printer failed         
#define D_EXO_API_PIO_ERR_WRITEPRINTERFAILED                                  0x40000007 // Error code indicating write printer failed        
#define D_EXO_API_PIO_ERR_UNKNOWNPRINTER                                      0x40000008 // Error code indicating unknown printer             

//-- Maximum values
#define D_EXO_API_PIO_S_PRINTER_NAME                                          200        // Maximum length of printer name (excl. zero)       
#define D_EXO_API_PIO_S_COMMAND                                               2000       // Maximum length of command (excl. zero)            

//-- Protocol revision 
#define D_EXO_API_PCKT_REVISION                                               0          // Revision of the data packets

//-- Data request id's which correspond with bits in parameter [n] in emulation command "GS A+[n]"
//.. After reception of this command, the printer will send a sequence of requested data packets
//.. The packet data "[d1]+[dn]" immediately follows the packet header.
#define D_EXO_API_DATA_REQUEST_ID_PRINTER_STATUS                              0x01       // Bit number for inquiring printer status
#define D_EXO_API_DATA_REQUEST_ID_PRINTER_INFO                                0x02       // Bit number for inquiring printer info
#define D_EXO_API_DATA_REQUEST_ID_PRINTER_SENSORS                             0x04       // Bit number for inquiring sensor status
#define D_EXO_API_DATA_REQUEST_ID_PRINTER_FLASH                               0x08       // Bit number for inquiring flash contents
#define D_EXO_API_DATA_REQUEST_ID_PRESENTER_STATUS                            0x10       // Bit number for inquiring presenter status (Available from firmware version R4-2.00)
#define D_EXO_API_DATA_REQUEST_ID_PRINTER_LIFE_CYCLE                          0x20       // Bit number for inquiring life cycle data (Available from firmware version R4-V1.03b)

//-- Data packets id's which correspond with parameter ubId in TS_EXO_API_PCKT_HEADER
//.. Note that the packet header "ESC [FF]+[i]+[n]" has [i] as packet identifier and [n] as packet data size.
//.. The packet data "[d1]+[dn]" immediately follows the packet header.
#define D_EXO_API_DATA_PACKET_ID_PRINTER_STATUS                               0x02       // Packet identifier of a printer status packet
#define D_EXO_API_DATA_PACKET_ID_PRINTER_INFO                                 0x03       // Packet identifier of a printer info packet
#define D_EXO_API_DATA_PACKET_ID_PRINTER_SENSORS                              0x04       // Packet identifier of a sensor status packet
#define D_EXO_API_DATA_PACKET_ID_PRINTER_FLASH                                0x05       // Packet identifier of a flash contents packet
#define D_EXO_API_DATA_PACKET_ID_PRESENTER_STATUS                             0x06       // Packet identifier of a presenter status packet (Available from firmware version R4-2.00)
#define D_EXO_API_DATA_PACKET_ID_PRINTER_LIFE_CYCLE                           0x07       // Packet identifier of a life cycle packet (Available from firmware version R4-V1.03b)

//-- Printer status packet -> printer status dword bits
#define D_EXO_API_PRINTER_STATUS_PSDW_PRINTER_ERROR                           0x00000001  
#define D_EXO_API_PRINTER_STATUS_PSDW_PRINT_HEAD_TEMP_ALERT                   0x00000002
#define D_EXO_API_PRINTER_STATUS_PSDW_FLASH_CHECKSUM_ERROR                    0x00000004
#define D_EXO_API_PRINTER_STATUS_PSDW_PRINTER_STALLED                         0x00000008
#define D_EXO_API_PRINTER_STATUS_PSDW_PAPER_OUT_DETECTED                      0x00000010
#define D_EXO_API_PRINTER_STATUS_PSDW_PAPER_LOW_DETECTED                      0x00000020
#define D_EXO_API_PRINTER_STATUS_PSDW_PAPER_MARK_DETECTED                     0x00000040
#define D_EXO_API_PRINTER_STATUS_PSDW_PAPER_IN_CHUTE_DETECTED                 0x00000080
#define D_EXO_API_PRINTER_STATUS_PSDW_PRINT_HEAD_UP_DETECTED                  0x00000100
#define D_EXO_API_PRINTER_STATUS_PSDW_LAST_PRINTOUT_LOST                      0x00000200
#define D_EXO_API_PRINTER_STATUS_PSDW_AUXILIARY_SENSOR_ACTIVE                 0x00000400
#define D_EXO_API_PRINTER_STATUS_PSDW_SYSTEM_FAILURE                          0x00000800
#define D_EXO_API_PRINTER_STATUS_PSDW_POWER_FAILURE                           0x00001000
#define D_EXO_API_PRINTER_STATUS_PSDW_CUSTOMER_FLAG_1                         0x00002000
#define D_EXO_API_PRINTER_STATUS_PSDW_CUSTOMER_FLAG_2                         0x00004000
#define D_EXO_API_PRINTER_STATUS_PSDW_PRINTER_NOT_READY                       0x00008000
#define D_EXO_API_PRINTER_STATUS_PSDW_PRINTER_BUSY                            0x00010000   // Available from firmware version R4-V1.04h
#define D_EXO_API_PRINTER_STATUS_PSDW_EEPROM_MISSING                          0x00020000   // Available from firmware version R3-V1.02g
#define D_EXO_API_PRINTER_STATUS_PSDW_PRESENTER_AVAILABLE                     0x00040000   // Available from firmware version R4-V1.04h
#define D_EXO_API_PRINTER_STATUS_PSDW_PRESENTER_ACTIVE                        0x00080000   // Available from firmware version R4-V1.04h
#define D_EXO_API_PRINTER_STATUS_PSDW_PARCUT_HOLDING_PRINTOUT                 0x00300000   // Available from firmware version R3-V1.02t
#define D_EXO_API_PRINTER_STATUS_PSDW_PARCUT_PRINTOUT_TAKEN                   0x00100000   // Available from firmware version R3-V1.02t
#define D_EXO_API_PRINTER_STATUS_PSDW_PARCUT_PRINTOUT_REMOVED                 0x00200000   // Available from firmware version R4-V1.02t

//-- Printer status packet -> Printer error word codes (high byte is WHAT, low byte is WHEN)
#define D_EXO_API_PRINTER_STATUS_PEW_MSB_WHAT_PAPER_JAMMED                    0x01  
#define D_EXO_API_PRINTER_STATUS_PEW_MSB_WHAT_CUTTER_JAMMED                   0x02  
#define D_EXO_API_PRINTER_STATUS_PEW_MSB_WHAT_PRESENTER_JAMMED                0x03
#define D_EXO_API_PRINTER_STATUS_PEW_MSB_WHAT_ERROR(ERR,WHAT)                 (((ERR)&0xFF00) == (((WHAT) & 0x00FF) << 8))
#define D_EXO_API_PRINTER_STATUS_PEW_LSB_WHEN_DURING_PRINT                    0x01
#define D_EXO_API_PRINTER_STATUS_PEW_LSB_WHEN_DURING_PAPER_LOAD               0x02
#define D_EXO_API_PRINTER_STATUS_PEW_LSB_WHEN_DURING_PAPER_END                0x03
#define D_EXO_API_PRINTER_STATUS_PEW_LSB_WHEN_DURING_INTIALIZATION            0x04
#define D_EXO_API_PRINTER_STATUS_PEW_LSB_WHEN_DURING_END_OF_PRINT             0x05
#define D_EXO_API_PRINTER_STATUS_PEW_LSB_WHEN_WHILE_IDLE                      0x06
#define D_EXO_API_PRINTER_STATUS_PEW_LSB_WHEN_WHILE_LOADING                   0x07 
#define D_EXO_API_PRINTER_STATUS_PEW_LSB_WHEN_WHILE_PRESENTING                0x08
#define D_EXO_API_PRINTER_STATUS_PEW_LSB_WHEN_WHILE_REJECTING                 0x09
#define D_EXO_API_PRINTER_STATUS_PEW_LSB_WHEN_WHILE_CANCELING                 0x0A
#define D_EXO_API_PRINTER_STATUS_PEW_LSB_WHEN_DURING_EJECT                    0x0B
#define D_EXO_API_PRINTER_STATUS_PEW_LSB_WHEN_DURING_TEST                     0x0C
#define D_EXO_API_PRINTER_STATUS_PEW_LSB_WHEN_WHILE_COUPLING                  0x0D
#define D_EXO_API_PRINTER_STATUS_PEW_LSB_WHEN_ERROR(ERR,WHEN)                 (((ERR)&0x00FF) == ((WHEN) & 0x00FF))

//-- Printer sensor packet -> printer sensor state (high nibble is type, low nibble is state)
#define D_EXO_API_PRINTER_SENSOR_PSS_MSN_NONE                                 0x00
#define D_EXO_API_PRINTER_SENSOR_PSS_MSN_REFLEX                               0x10
#define D_EXO_API_PRINTER_SENSOR_PSS_MSN_TLIGHT                               0x20
#define D_EXO_API_PRINTER_SENSOR_PSS_MSN_SWITCH                               0x30
#define D_EXO_API_PRINTER_SENSOR_PSS_LSN_NONE                                 0x00
#define D_EXO_API_PRINTER_SENSOR_PSS_LSN_NO_PAPER                             0x01
#define D_EXO_API_PRINTER_SENSOR_PSS_LSN_PAPER                                0x02
#define D_EXO_API_PRINTER_SENSOR_PSS_LSN_PARKED                               0x03
#define D_EXO_API_PRINTER_SENSOR_PSS_LSN_CUTTING                              0x04
#define D_EXO_API_PRINTER_SENSOR_PSS_LSN_HEAD_DOWN                            0x05
#define D_EXO_API_PRINTER_SENSOR_PSS_LSN_HEAD_UP                              0x06
#define D_EXO_API_PRINTER_SENSOR_PSS_LSN_ACTIVE                               0x07
#define D_EXO_API_PRINTER_SENSOR_PSS_LSN_INACTIVE                             0x08

//-- Printer flash packet -> printer flash area index/state 
#define D_EXO_API_PRINTER_FLASH_FA_INDEX_FIRMWARE                             0x00
#define D_EXO_API_PRINTER_FLASH_FA_INDEX_FONT_1                               0x01
#define D_EXO_API_PRINTER_FLASH_FA_INDEX_LOGO                                 0x02
#define D_EXO_API_PRINTER_FLASH_FA_INDEX_FONT_2                               0x03
#define D_EXO_API_PRINTER_FLASH_FA_INDEX_WIDE_FONT                            0x04
#define D_EXO_API_PRINTER_FLASH_FA_INDEX_IMAGES                               0x05
#define D_EXO_API_PRINTER_FLASH_FA_STATE_UNDEFINED                            0x00
#define D_EXO_API_PRINTER_FLASH_FA_STATE_OK                                   0x01
#define D_EXO_API_PRINTER_FLASH_FA_STATE_ERROR_CRC                            0x02
#define D_EXO_API_PRINTER_FLASH_FA_STATE_ERROR_TYPE                           0x03
#define D_EXO_API_PRINTER_FLASH_FA_STATE_ERROR_SIZE                           0x04

//-- Presenter status packet -> presenter status word
#define D_EXO_API_PRESENTER_STATUS_PSW_PRESENTER_READY                        0x0001
#define D_EXO_API_PRESENTER_STATUS_PSW_PRESENTER_BUSY                         0x0002
#define D_EXO_API_PRESENTER_STATUS_PSW_PRESENTER_OCCUPIED                     0x0004
#define D_EXO_API_PRESENTER_STATUS_PSW_PRINTOUTS_LOADED                       0x0008
#define D_EXO_API_PRESENTER_STATUS_PSW_PRESENTING_PRINTOUTS                   0x0010
#define D_EXO_API_PRESENTER_STATUS_PSW_REJECTING_PRINTOUTS                    0x0020
#define D_EXO_API_PRESENTER_STATUS_PSW_PRINTOUTS_TAKEN                        0x0040
#define D_EXO_API_PRESENTER_STATUS_PSW_PRINTOUTS_REJECTED                     0x0080
#define D_EXO_API_PRESENTER_STATUS_PSW_PRESENTER_JAMMED                       0x0100
#define D_EXO_API_PRESENTER_STATUS_PSW_PAPER_IN_CHUTE_DETECTED                0x0200

//-- Configuration data - customer sensors - paper pre end sensor - enumeration
#define D_EXO_API_CD_CS_PPES_MASK                                             0x7000
#define D_EXO_API_CD_CS_PPES_NONE                                             0x0000
#define D_EXO_API_CD_CS_PPES_REFLEX                                           0x1000
#define D_EXO_API_CD_CS_PPES_TLIGHT                                           0x2000
#define D_EXO_API_CD_CS_PPES_SWITCH                                           0x3000
#define D_EXO_API_CD_CS_PPES_DETECT_PAPER_WHEN_LOW                            0x8000

//-- Configuration data - customer sensors - auxiliary sensor - enumeration
#define D_EXO_API_CD_CS_AUXS_MASK                                             0x0700
#define D_EXO_API_CD_CS_AUXS_NONE                                             0x0000
#define D_EXO_API_CD_CS_AUXS_REFLEX                                           0x0100
#define D_EXO_API_CD_CS_AUXS_TLIGHT                                           0x0200
#define D_EXO_API_CD_CS_AUXS_SWITCH                                           0x0300
#define D_EXO_API_CD_CS_AUXS_ACTIVE_WHEN_LOW                                  0x0800

//-- Configuration data - customer sensors - reserved
#define D_EXO_API_CD_CS_RES_MASK                                              0x00FF

//-- Configuration data - UART Baudrates  
#define D_EXO_API_CD_RS232_BAUDRATE_4800                                      0
#define D_EXO_API_CD_RS232_BAUDRATE_9600                                      1
#define D_EXO_API_CD_RS232_BAUDRATE_19200                                     2
#define D_EXO_API_CD_RS232_BAUDRATE_38400                                     3
#define D_EXO_API_CD_RS232_BAUDRATE_57600                                     4
#define D_EXO_API_CD_RS232_BAUDRATE_115200                                    5
#define D_EXO_API_CD_RS232_BAUDRATE_230400                                    6 // Not supported 
#define D_EXO_API_CD_RS232_BAUDRATE_460800                                    7 // Not supported 
#define D_EXO_API_CD_RS232_BAUDRATE_MAX                                       D_EXO_API_CD_RS232_BAUDRATE_115200
#define D_EXO_API_CD_RS232_BAUDRATE_DEF                                       D_EXO_API_CD_RS232_BAUDRATE_115200

//-- Configuration data - UART parity on/off
#define D_EXO_API_CD_RS232_PARITY_OFF                                         0
#define D_EXO_API_CD_RS232_PARITY_ON                                          1

//-- Configuration data - UART parity odd/even (if on)    
#define D_EXO_API_CD_RS232_PARITY_ODD                                         0
#define D_EXO_API_CD_RS232_PARITY_EVEN                                        1

//-- Configuration data - UART data bits (7/8)
#define D_EXO_API_CD_RS232_DATABIT_7                                          0 // Not supported 
#define D_EXO_API_CD_RS232_DATABIT_8                                          1
             
//-- Configuration data - UART stop bits (1/2)
#define D_EXO_API_CD_RS232_STOPBIT_1                                          0
#define D_EXO_API_CD_RS232_STOPBIT_2                                          1

//-- Configuration data - UART flow control (handshake)
#define D_EXO_API_CD_RS232_FLOWCNTL_NONE                                      0 // Not supported 
#define D_EXO_API_CD_RS232_FLOWCNTL_HW                                        1
#define D_EXO_API_CD_RS232_FLOWCNTL_SW                                        2 // Not supported 
 
//-- Configuration data - Wide font setting
#define D_EXO_API_CD_WF_NONE                                                  0 // Wide font disabled 
#define D_EXO_API_CD_WF_24X24_STANDARD                                        1 // Standard wide font      24X24 
#define D_EXO_API_CD_WF_24X24_GB3212                                          2 // GB2312 china wide font  24X24 
#define D_EXO_API_CD_WF_20X20_STANDARD                                        3 // Standard wide font      20X20 
#define D_EXO_API_CD_WF_20X20_KS5601                                          4 // KS5601 korean wide font 20X20 

//-- Configuration data - Options
#define D_EXO_API_CD_OPTION_CUTTER_INIT_ON_POWER_ON                           0x00000001
#define D_EXO_API_CD_OPTION_MARK_FEED_BEFORE_CUT                              0x00000002
#define D_EXO_API_CD_OPTION_PRINT_NO_INFO_ON_LOAD                             0x00000004
#define D_EXO_API_CD_OPTION_DISABLE_CUT_ON_LOAD                               0x00000008
#define D_EXO_API_CD_OPTION_INVALIDATE_PAPER_ON_LOAD                          0x00000010
#define D_EXO_API_CD_OPTION_NO_PAPER_FEED_AFTER_LOAD                          0x00000020
#define D_EXO_API_CD_OPTION_DISABLE_RETRACT_ON_PAPER_END                      0x00000040
#define D_EXO_API_CD_OPTION_CONTINUE_PRINT_ON_PAPER_END                       0x00000080
#define D_EXO_API_CD_OPTION_INVALIDATE_PAPER_ON_RETRACT                       0x00000100
#define D_EXO_API_CD_OPTION_INQUIRE_TOP_OF_FOR_ON_INIT                        0x00000200 
#define D_EXO_API_CD_OPTION_ENABLE_AUTOMATIC_RECOVERY_ON_INIT                 0x00000400 // Obsolete since Firmware R4-V2.00a 
#define D_EXO_API_CD_OPTION_INVALIDATE_PAPER_ON_INIT                          0x00000800
#define D_EXO_API_CD_OPTION_ADD_CUSTOMER_FLAG_TO_USB_VERSION                  0x00001000
#define D_EXO_API_CD_OPTION_PRINT_WHOLE_OBJECTS_ONLY                          0x00002000
#define D_EXO_API_CD_OPTION_ASSIGN_MODEL_SPECIFIC_USB_DEVICE_ID               0x00004000
#define D_EXO_API_CD_OPTION_DISABLE_RETRACT_AT_PRINT_START                    0x00008000
#define D_EXO_API_CD_OPTION_PRE_PULL_FORM_BEFORE_PRINT                        0x00010000
#define D_EXO_API_CD_OPTION_USE_IMPROVED_BURN_TIME_DETERMINATION              0x00020000 // AVAILABLE SINCE FIRMWARE R4-V2.00a
#define D_EXO_API_CD_OPTION_DISABLE_AUTO_PRESENTER_REJECT_FEATURE             0x00040000 // AVAILABLE SINCE FIRMWARE R4-V2.00b
#define D_EXO_API_CD_OPTION_DISABLE_PAPER_REJECT_ON_PAPER_LOAD_FAIL           0x00080000 // AVAILABLE SINCE FIRMWARE R4-V2.00c 
#define D_EXO_API_CD_OPTION_DISABLE_SCAN_OUTSIDE_MARK_AREA                    0x00100000 // AVAILABLE SINCE FIRMWARE R5-V2.01a 

//-- Sensor adjustment values (only available if sensor current adjustment feature is available)
#define D_EXO_API_CD_SCA_SETTING_DYNAMIC_DURING_INITIAL_PAPER_LOAD_ONLY       0          // Single dynamic adjustment (if possible)
#define D_EXO_API_CD_SCA_SETTING_FIXED_2BIT_10_0_mA                           1          // Sensor current fixed to 10,0 mA
#define D_EXO_API_CD_SCA_SETTING_FIXED_2BIT_15_0_mA                           2          // Sensor current fixed to 15,0 mA
#define D_EXO_API_CD_SCA_SETTING_FIXED_2BIT_20_0_mA                           3          // Sensor current fixed to 20,0 mA
#define D_EXO_API_CD_SCA_SETTING_FIXED_2BIT_24_0_mA                           4          // Sensor current fixed to 24,0 mA
#define D_EXO_API_CD_SCA_SETTING_FIXED_4BIT_09_6_mA                           1          // Sensor current fixed to  9,6 mA
#define D_EXO_API_CD_SCA_SETTING_FIXED_4BIT_10_8_mA                           2          // Sensor current fixed to 10,8 mA
#define D_EXO_API_CD_SCA_SETTING_FIXED_4BIT_11_8_mA                           3          // Sensor current fixed to 11,8 mA
#define D_EXO_API_CD_SCA_SETTING_FIXED_4BIT_13_1_mA                           4          // Sensor current fixed to 13,1 mA
#define D_EXO_API_CD_SCA_SETTING_FIXED_4BIT_14_3_mA                           5          // Sensor current fixed to 14,3 mA
#define D_EXO_API_CD_SCA_SETTING_FIXED_4BIT_15_6_mA                           6          // Sensor current fixed to 15,6 mA
#define D_EXO_API_CD_SCA_SETTING_FIXED_4BIT_16_6_mA                           7          // Sensor current fixed to 16,6 mA
#define D_EXO_API_CD_SCA_SETTING_FIXED_4BIT_17_8_mA                           8          // Sensor current fixed to 17,8 mA
#define D_EXO_API_CD_SCA_SETTING_FIXED_4BIT_18_0_mA                           9          // Sensor current fixed to 18,0 mA
#define D_EXO_API_CD_SCA_SETTING_FIXED_4BIT_19_3_mA                           10         // Sensor current fixed to 19,3 mA
#define D_EXO_API_CD_SCA_SETTING_FIXED_4BIT_20_2_mA                           11         // Sensor current fixed to 20,2 mA
#define D_EXO_API_CD_SCA_SETTING_FIXED_4BIT_21_5_mA                           12         // Sensor current fixed to 21,5 mA
#define D_EXO_API_CD_SCA_SETTING_FIXED_4BIT_22_7_mA                           13         // Sensor current fixed to 22,7 mA
#define D_EXO_API_CD_SCA_SETTING_FIXED_4BIT_23_9_mA                           14         // Sensor current fixed to 23,9 mA
#define D_EXO_API_CD_SCA_SETTING_FIXED_4BIT_24_9_mA                           15         // Sensor current fixed to 24,9 mA
#define D_EXO_API_CD_SCA_SETTING_FIXED_4BIT_26_1_mA                           16         // Sensor current fixed to 26,1 mA
#define D_EXO_API_CD_SCA_SETTING_DYNAMIC_DURING_EVERY_PAPER_LOAD              255        // Default dynamic adjustment (if possible)

/*
** TYPES
*/

//-- Printer packet header (precedes printer status/info/etc. packets)
#pragma pack(1) 
typedef struct   
   { BYTE                   ubSync1;                                // First synchronization byte (must be 0x1B)
     BYTE                   ubSync2;                                // Second synchronization byte (must be 0xFF)
     BYTE                   ubId;                                   // Identification of packet 
     BYTE                   ubLength;                               // Length of header and data part
   } TS_EXO_API_PCKT_HEADER;                                        // Packet header
#pragma pack() 

//-- Printer status packet (identifier in preceding header is 2)
#pragma pack(1) 
typedef struct   
   { DWORD                  dwStatus;                               // Printer status dword as in D_EXO_API_PRINTER_STATUS_PSDW_...
     BYTE                   ubPrintJobId;                           // Id of print job
     SHORT                  siPrintHeadTempC;                       // Printhead temperature in degrees celcius                          (ADC#02)
     WORD                   wBoardVoltageTv;                        // Board voltage in 1/10 volt
     BYTE                   ubState;                                // Status of paper control
     WORD                   wError;                                 // Printer error word as in D_EXO_API_PRINTER_STATUS_PEW_...
     BYTE                   ubReserved[2];                          // Reserved bytes
   } TS_EXO_API_PCKT_PRINTER_STATUS;                                // Printer status packet TS_EXO_API_PCKT_PRINTER_STATUS
#pragma pack() 

//-- Printer info packet (identifier in preceding header is 3)
#pragma pack(1) 
typedef struct 
   { BYTE                   ubProtocolRevision;                     // Revision of communication protocol (see D_EXO_API_PCKT_REVISION)
     CHAR                   szPartNr[16+1];                         // Part number, inluding 0 terminator
     CHAR                   szSerialNr[16+1];                       // Serial number, inluding 0 terminator
     CHAR                   szDateOfManuf[16+1];                    // Date of manufacturing, inluding 0 terminator
     DWORD                  dwSysConfig;                            // Configuration code
     DWORD                  dwSysSensor;                            // Sensor code
     DWORD                  dwSysFeature;                           // Feature code
     CHAR                   szFwPartNr[16+1];                       // Part number, inluding 0 terminator 
     CHAR                   szFwVersion[10+1];                      // Firmware version  Rx-Vy.zzb
     CHAR                   szFwDate[12+1];                         // Firmware date     Mmm dd yyyy (ANSI standard).
     DWORD                  dwFwPatch;                              // Firmware patch code
   } TS_EXO_API_PCKT_PRINTER_INFO;                                  // Printer info packet
#pragma pack() 

//-- Printer sensor packet (identifier in preceding header is 4)
#pragma pack(1) 
typedef struct
   { BYTE                   ubProtocolRevision;                     // Revision of communication protocol
     BYTE                   ubAdcMeasurement[16];                   // ADC channel #00..#15 measurements in domain 0=0V..255=5V                (ADC#XX)
     WORD                   wDigitalInput;                          // DIN digital inputs bits #00..#15                                        (DIN#XX)
     SHORT                  siPrintHeadTempC;                       // Printhead temperature in degrees celcius                                (ADC#02)
     WORD                   wBoardVoltageTv;                        // Board voltage in tenths of volt                                         (ADC#01)
     BYTE                   ubPaperPreEndSensorState;               // State byte for paper pre end sensor   (D_EXO_API_PRINTER_SENSOR_PSS_..) (ADC#03)
     BYTE                   ubPaperEntrySensor1State;               // State byte for paper entry sensor #1  (D_EXO_API_PRINTER_SENSOR_PSS_..) (ADC#04)
     BYTE                   ubPaperEntrySensor2State;               // State byte for paper entry sensor #2  (D_EXO_API_PRINTER_SENSOR_PSS_..) (ADC#05)
     BYTE                   ubHeadUpSensorState;                    // State byte for head up sensor         (D_EXO_API_PRINTER_SENSOR_PSS_..) (DIN#00)
     BYTE                   ubCutterSensor1State;                   // State byte for cutter sensor #1       (D_EXO_API_PRINTER_SENSOR_PSS_..) (DIN#01)
     BYTE                   ubCutterSensor2State;                   // State byte for cutter sensor #2       (D_EXO_API_PRINTER_SENSOR_PSS_..) (DIN#02)
     BYTE                   ubPaperExitSensorState;                 // State byte for paper exit sensor      (D_EXO_API_PRINTER_SENSOR_PSS_..) (ADC#00)
     BYTE                   ubAuxiliarySensorState;                 // State byte for auxiliary sensor       (D_EXO_API_PRINTER_SENSOR_PSS_..) (ADC#06)
     BYTE                   ubPresenterSensor1State;                // State byte for presenter sensor #1    (D_EXO_API_PRINTER_SENSOR_PSS_..) (ADC#00)
     BYTE                   ubPresenterSensor2State;                // State byte for presenter sensor #2    (D_EXO_API_PRINTER_SENSOR_PSS_..) (ADC#06)
     BYTE                   ubReserved[2];                          // Reserved bytes, must be 0
   } TS_EXO_API_PCKT_PRINTER_SENSOR;                                // Printer sensor packet
#pragma pack() 

//-- Printer flash packet (identifier in preceding header is 5)
#pragma pack(1) 
typedef struct 
   { BYTE                   ubProtocolRevision;                     // Revision of communication protocol
     CHAR                   szInfo[6][20+1];                        // Flash area info, indexed by D_EXO_API_PRINTER_FLASH_FA_INDEX_..., inluding 0 terminator
     WORD                   wCrc16[6][2];                           // Flash area 16 bit checksum, indexed by D_EXO_API_PRINTER_FLASH_FA_INDEX_..., 0=stored and 1=calculated
     BYTE                   ubState[6];                             // Flash area state, indexed by D_EXO_API_PRINTER_FLASH_FA_INDEX_..., 
     BYTE                   ubReserved[6];                          // Reserved bytes, must be 0
   } TS_EXO_API_PCKT_PRINTER_FLASH;                                 // Printer flash packet
#pragma pack() 

//-- Presenter status packet (identifier in preceding header is 6)
#pragma pack(1) 
typedef struct  
   { BYTE                   ubProtocolRevision;                     // Revision of communication protocol
     BYTE                   ubType;                                 // Type of presenter (0 is NONE)
     WORD                   wStatus;                                // Presenter status word bits as in D_EXO_API_PRESENTER_STATUS_PSW_...
     BYTE                   ubState;                                // State of presenter control (idle/loading/presenting/rejecting, etc.)
     BYTE                   ubNrOfLoadedPages;                      // Total number of currently loaded  (bundled) printouts
     DWORD                  dwNrOfProcessedPages;                   // Total number of processed pages since start / power on
     DWORD                  dwNrOfEjectedPages;                     // Total number of ejected   pages since start / power on
     DWORD                  dwNrOfRejectedPages;                    // Total number of rejected  pages since start / power on
     BYTE                   ubReserved[8];                          // Reserved bytes, must be 0
   } TS_EXO_API_PCKT_PRESENTER_STATUS;                              // Presenter status packet
#pragma pack() 

//-- Life cycle data packet
#pragma pack(1) 
typedef struct 
   { BYTE                   ubProtocolRevision;                    // Revision of communication protocol
     DWORD                  dwTimePoweredS;                        // Total time that the printer is powered in sec
     DWORD                  dwDistanceSteppedMm;                   // Total distance stepped in mm
     DWORD                  dwDistanceBurnedMm;                    // Total distance burned in mm
     DWORD                  dwPaperTransportedMm;                  // Total length of transported paper in mm
     DWORD                  dwNrOfSystemStarts;                    // Total number of system starts
     DWORD                  dwNrOfHardResets;                      // Total number of hardware resets 
     DWORD                  dwNrOfPaperCuts;                       // Total number of paper cuts 
     WORD                   wNrOfPaperLoads;                       // Total number of paper loads 
     BYTE                   ubReserved[8];                         // Reserved bytes (2 DWORDs, zero initialized)
   }  TS_EXO_API_PCKT_PRINTER_LIFE_CYCLE;                          // Life cycle packet
#pragma pack() 

//-- Configuration data structure
#pragma pack(1) // Byte aligned
typedef struct 
   { WORD                   wRevisionNumber;                       // Structure revision number 
     WORD                   wSizeOfBlock;                          // Size of this structure
     CHAR                   szCustSerialNr[16+1];                  // Customer-serial number, zero is unused
     CHAR                   szCustPartNr[16+1];                    // Customer-part number, zero is unused
     BYTE                   ubCustFlags;                           // Customer specific flags
     BYTE                   ubBaudRate;                            // Baudrate matching one of D_EXO_API_CD_RS232_BAUDRATE_...
     BYTE                   ubParityOnOff;                         // Parity matching one of D_EXO_API_CD_RS232_PARITY_... (on/off)
     BYTE                   ubParity;                              // Parity matching one of D_EXO_API_CD_RS232_PARITY_... (even/odd, if on)
     BYTE                   ubDataBits;                            // Data bits matching one of D_EXO_API_CD_RS232_DATABIT_... (7/ 8)
     BYTE                   ubStopBits;                            // Stop bits matching one of D_EXO_API_CD_RS232_STOPBIT_... (1/2)
     BYTE                   ubFlowControl;                         // Flow control matching one of D_EXO_API_CD_RS232_FLOWCNTL_... (SW/HW/NO)
     BYTE                   ubBlockHostTxOnPaperOut;               // Flag indicating disable host TX on paper out (RS232-HW/SW flow control only)
     BYTE                   ubWideFont;                            // Enumeration indicating wide font set enabled if non zero
     WORD                   wPrintSpeedTmms;                       // Print speed (default) in 1/10 mm/sec
     CHAR                   cPrintDensity;                         // Print density (default) in percent
     BYTE                   ubDhisBurnFac;                         // Dot history burn factor in percent of total burn time (zero indicates OFF)
     BYTE                   ubMultiStrobeFac;                      // Multi strobe counter, zero is undefined
     CHAR                   asbBurnTimeCorr[11];                   // Burn time corrections in us for -30?.+70°C with 10°C interval
     DWORD                  dwOptions;                             // Customer options
     DWORD                  dwFormLengthYm;                        // Maximum form length in micrometer
     DWORD                  dwMarkCutDisYm;                        // Distance from end of black/hole mark to cut position in micrometer
     WORD                   wMarkSizeYm;                           // Size of a black/hole mark in micrometer
     BYTE                   ubPaperParkPos;                        // Paper park position 0 or 1
     DWORD                  dwPaperLoadFeedYm;                     // Feed length after paper load in micrometer
     WORD                   wCustSensor;                           // Customer sensors as in D_EXO_API_CD_CS_.... 
     WORD                   wPaperRemovalPeriodSec;                // Duraation of the paper removal period after partial cut in seconds
     WORD                   wPaperEndDetectDisYm;                  // Minimum distance required before detecting paper end in micrometer
     DWORD                  dwPaperPresentationOffsetYm;           // Distance in which paper if forwarded after cut in micrometer (from firwmare 1.02)
     SHORT                  iMarkCutCorrectionYm;                  // Correction of mark cut position in micrometer (from firwmare 1.02)
     SHORT                  iPrintCorrectionYm;                    // Correction of print start position in micrometer (from firwmare 1.02)
     BYTE                   ubMarkThresholdCorrection;             // Mark threshold correction in 10% (1/10 volt) resolution (from firmware 1.03j)
     WORD                   wPaperLoadSpeedTmms;                   // Paper load    speed in 1/10 mm/sec (from firmware 2.00a)
     WORD                   wPaperReverseSpeedTmms;                // Paper reverse speed in 1/10 mm/sec (from firmware 2.00a)
     WORD                   wPaperAdvanceSpeedTmms;                // Paper advance speed in 1/10 mm/sec (from firmware 2.00a)
     BYTE                   ubScaPaperEntrySensor;                 // Paper entry sensor current adjustment (SCA) as in D_EXO_API_CD_SCA_... (from firmware 2.01g)
     BYTE                   ubScaPaperExitSensor;                  // Printer exit sensor current adjustment (SCA) as in D_EXO_API_CD_SCA_... (from firmware 2.01g)
     BYTE                   ubScaPresenterExitSensor;              // Presenter exit sensor current adjustment (SCA) as in D_EXO_API_CD_SCA_... (from firmware 2.01g)
     BYTE                   ubPreMarkValidationDistanceTmm;        // Pre-mark validation distance in 1/10 mm (from firmware 2.01i)
     BYTE                   ubPostMarkValidationDistanceTmm;       // Post-mark validation distance in 1/10 mm (from firmware 2.01i  )
     BYTE                   ubScaPaperEntrySensorDynamicMin;       // Minimum dynamic paper entry sensor current adjustment (SCA) as in D_EXO_SM_SCA_... (from firmware 2.01i)
     BYTE                   ubScaPaperEntrySensorDynamicMax;       // Maximum dynamic paper entry sensor current adjustment (SCA) as in D_EXO_SM_SCA_... (from firmware 2.01i)
     BYTE                   ubReserved[8];                         // Reserved byte 0-8 must be zero
     WORD                   wCrc16;                                // 16 Bit checksum of structure
   } TS_EXO_API_CONFIG_DATA;                                       // Extendo configuration data structure as uploaded to and stored in flash
#define D_EXO_API_CONFIG_DATA_REV 1                                // Revision of configuration data
#pragma pack() 

/*
** FUNCTIONS
*/

//-- Printer access functions
HANDLE                    WINAPI Exo_Api_Pio_PrinterOpen                  (LPSTR pszPrinterName, DWORD dwOptions, DWORD dwTimeOutMs);
bool                      WINAPI Exo_Api_Pio_PrinterClose                 (HANDLE hPrinterIo);
DWORD                     WINAPI Exo_Api_Pio_PrinterRead                  (HANDLE hPrinterIo, unsigned char * pubData, DWORD nData, DWORD dwTimeOutMs);
bool                      WINAPI Exo_Api_Pio_PrinterReadClear             (HANDLE hPrinterIo);
DWORD                     WINAPI Exo_Api_Pio_PrinterWrite                 (HANDLE hPrinterIo, unsigned char * pubData, DWORD nData, DWORD dwTimeOutMs);
bool                      WINAPI Exo_Api_Pio_PrinterPrintImage            (HANDLE hPrinterIo, LPSTR pszImageFile, DWORD dwTimeOutMs);

//-- Printer enumeration functions
HANDLE                    WINAPI Exo_Api_Pe_PrinterEnumStart              (void);
bool                      WINAPI Exo_Api_Pe_PrinterEnumEnd                (HANDLE hPrinterEnum);
LPSTR                     WINAPI Exo_Api_Pe_PrinterEnum                   (HANDLE hPrinterEnum, bool fReset);
bool                      WINAPI Exo_Api_Pe_ValidatePrinterName           (LPSTR lpszPrinter);

/*
** VARIABLES
*/

#endif 
