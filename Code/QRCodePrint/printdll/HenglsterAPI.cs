using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace QRCodePrint.printdll
{
    public class Henglster
    {
        public const byte D_EXO_API_DATA_PACKET_ID_PRESENTER_STATUS = 6;
        public const byte D_EXO_API_DATA_PACKET_ID_PRINTER_FLASH = 5;
        public const byte D_EXO_API_DATA_PACKET_ID_PRINTER_INFO = 3;
        public const byte D_EXO_API_DATA_PACKET_ID_PRINTER_LIFE_CYCLE = 7;
        public const byte D_EXO_API_DATA_PACKET_ID_PRINTER_SENSORS = 4;
        public const byte D_EXO_API_DATA_PACKET_ID_PRINTER_STATUS = 2;
        public const byte D_EXO_API_DATA_REQUEST_ID_PRESENTER_STATUS = 0x10;
        public const byte D_EXO_API_DATA_REQUEST_ID_PRINTER_FLASH = 8;
        public const byte D_EXO_API_DATA_REQUEST_ID_PRINTER_INFO = 2;
        public const byte D_EXO_API_DATA_REQUEST_ID_PRINTER_LIFE_CYCLE = 0x20;
        public const byte D_EXO_API_DATA_REQUEST_ID_PRINTER_SENSORS = 4;
        public const byte D_EXO_API_DATA_REQUEST_ID_PRINTER_STATUS = 1;
        public const int D_EXO_API_PCKT_REVISION = 0;
        public const uint D_EXO_API_PIO_ERR_ENDOFENUM = 0x40000004;
        public const uint D_EXO_API_PIO_ERR_INVALIDPARAMETER = 0x40000003;
        public const uint D_EXO_API_PIO_ERR_OPENPRINTERFAILED = 0x40000005;
        public const uint D_EXO_API_PIO_ERR_OUTOFMEMORY = 0x40000001;
        public const uint D_EXO_API_PIO_ERR_READPRINTERFAILED = 0x40000006;
        public const uint D_EXO_API_PIO_ERR_STOPSPOOLERFAILED = 0x40000002;
        public const uint D_EXO_API_PIO_ERR_UNKNOWNPRINTER = 0x40000008;
        public const uint D_EXO_API_PIO_ERR_WRITEPRINTERFAILED = 0x40000007;
        public const uint D_EXO_API_PIO_OPT_NO_SYNCHRONIZE = 1;
        public const uint D_EXO_API_PIO_OPT_NONE = 0;
        public const int D_EXO_API_PIO_S_COMMAND = 0x7d0;
        public const int D_EXO_API_PIO_S_PRINTER_NAME = 200;
        public const ushort D_EXO_API_PRESENTER_STATUS_PSW_EJECTING_PRINTOUTS = 0x40;
        public const ushort D_EXO_API_PRESENTER_STATUS_PSW_LAST_PRINTOUTS_REJECTED = 0x200;
        public const ushort D_EXO_API_PRESENTER_STATUS_PSW_LAST_PRINTOUTS_TAKEN = 0x100;
        public const ushort D_EXO_API_PRESENTER_STATUS_PSW_LOADING_PRINTOUTS = 0x10;
        public const ushort D_EXO_API_PRESENTER_STATUS_PSW_PRESENTER_BUSY = 2;
        public const ushort D_EXO_API_PRESENTER_STATUS_PSW_PRESENTER_JAMMED = 8;
        public const ushort D_EXO_API_PRESENTER_STATUS_PSW_PRESENTER_OCCUPIED = 4;
        public const ushort D_EXO_API_PRESENTER_STATUS_PSW_PRESENTER_READY = 1;
        public const ushort D_EXO_API_PRESENTER_STATUS_PSW_PRESENTING_PRINTOUTS = 0x20;
        public const ushort D_EXO_API_PRESENTER_STATUS_PSW_REJECTING_PRINTOUTS = 0x80;
        public const byte D_EXO_API_PRINTER_FLASH_FA_INDEX_FIRMWARE = 0;
        public const byte D_EXO_API_PRINTER_FLASH_FA_INDEX_FONT_1 = 1;
        public const byte D_EXO_API_PRINTER_FLASH_FA_INDEX_FONT_2 = 3;
        public const byte D_EXO_API_PRINTER_FLASH_FA_INDEX_IMAGES = 5;
        public const byte D_EXO_API_PRINTER_FLASH_FA_INDEX_LOGO = 2;
        public const byte D_EXO_API_PRINTER_FLASH_FA_INDEX_WIDE_FONT = 4;
        public const byte D_EXO_API_PRINTER_FLASH_FA_STATE_ERROR_CRC = 2;
        public const byte D_EXO_API_PRINTER_FLASH_FA_STATE_ERROR_SIZE = 4;
        public const byte D_EXO_API_PRINTER_FLASH_FA_STATE_ERROR_TYPE = 3;
        public const byte D_EXO_API_PRINTER_FLASH_FA_STATE_OK = 1;
        public const byte D_EXO_API_PRINTER_FLASH_FA_STATE_UNDEFINED = 0;
        public const byte D_EXO_API_PRINTER_SENSOR_PSS_LSN_ACTIVE = 7;
        public const byte D_EXO_API_PRINTER_SENSOR_PSS_LSN_CUTTING = 4;
        public const byte D_EXO_API_PRINTER_SENSOR_PSS_LSN_HEAD_DOWN = 5;
        public const byte D_EXO_API_PRINTER_SENSOR_PSS_LSN_HEAD_UP = 6;
        public const byte D_EXO_API_PRINTER_SENSOR_PSS_LSN_INACTIVE = 8;
        public const byte D_EXO_API_PRINTER_SENSOR_PSS_LSN_NO_PAPER = 1;
        public const byte D_EXO_API_PRINTER_SENSOR_PSS_LSN_NONE = 0;
        public const byte D_EXO_API_PRINTER_SENSOR_PSS_LSN_PAPER = 2;
        public const byte D_EXO_API_PRINTER_SENSOR_PSS_LSN_PARKED = 3;
        public const byte D_EXO_API_PRINTER_SENSOR_PSS_MSN_NONE = 0;
        public const byte D_EXO_API_PRINTER_SENSOR_PSS_MSN_REFLEX = 0x10;
        public const byte D_EXO_API_PRINTER_SENSOR_PSS_MSN_SWITCH = 0x30;
        public const byte D_EXO_API_PRINTER_SENSOR_PSS_MSN_TLIGHT = 0x20;
        public const byte D_EXO_API_PRINTER_STATUS_PEW_LSB_WHEN_DURING_END_OF_PRINT = 5;
        public const byte D_EXO_API_PRINTER_STATUS_PEW_LSB_WHEN_DURING_INTIALIZATION = 4;
        public const byte D_EXO_API_PRINTER_STATUS_PEW_LSB_WHEN_DURING_PAPER_END = 3;
        public const byte D_EXO_API_PRINTER_STATUS_PEW_LSB_WHEN_DURING_PAPER_LOAD = 2;
        public const byte D_EXO_API_PRINTER_STATUS_PEW_LSB_WHEN_DURING_PRINT = 1;
        public const byte D_EXO_API_PRINTER_STATUS_PEW_LSB_WHEN_WHILE_IDLE = 6;
        public const byte D_EXO_API_PRINTER_STATUS_PEW_LSB_WHEN_WHILE_LOADING = 7;
        public const byte D_EXO_API_PRINTER_STATUS_PEW_LSB_WHEN_WHILE_PRESENTING = 8;
        public const byte D_EXO_API_PRINTER_STATUS_PEW_LSB_WHEN_WHILE_REJECTING = 9;
        public const byte D_EXO_API_PRINTER_STATUS_PEW_MSB_WHAT_CUTTER_JAMMED = 2;
        public const byte D_EXO_API_PRINTER_STATUS_PEW_MSB_WHAT_PAPER_JAMMED = 1;
        public const byte D_EXO_API_PRINTER_STATUS_PEW_MSB_WHAT_PRESENTER_JAMMED = 3;
        public const uint D_EXO_API_PRINTER_STATUS_PSDW_AUXILIARY_SENSOR_ACTIVE = 0x400;
        public const uint D_EXO_API_PRINTER_STATUS_PSDW_CUSTOMER_FLAG_1 = 0x2000;
        public const uint D_EXO_API_PRINTER_STATUS_PSDW_CUSTOMER_FLAG_2 = 0x4000;
        public const uint D_EXO_API_PRINTER_STATUS_PSDW_EEPROM_MISSING = 0x20000;
        public const uint D_EXO_API_PRINTER_STATUS_PSDW_FLASH_CHECKSUM_ERROR = 4;
        public const uint D_EXO_API_PRINTER_STATUS_PSDW_LAST_PRINTOUT_LOST = 0x200;
        public const uint D_EXO_API_PRINTER_STATUS_PSDW_PAPER_IN_CHUTE_DETECTED = 0x80;
        public const uint D_EXO_API_PRINTER_STATUS_PSDW_PAPER_LOW_DETECTED = 0x20;
        public const uint D_EXO_API_PRINTER_STATUS_PSDW_PAPER_MARK_DETECTED = 0x40;
        public const uint D_EXO_API_PRINTER_STATUS_PSDW_PAPER_OUT_DETECTED = 0x10;
        public const uint D_EXO_API_PRINTER_STATUS_PSDW_PARCUT_HOLDING_PRINTOUT = 0x300000;
        public const uint D_EXO_API_PRINTER_STATUS_PSDW_PARCUT_PRINTOUT_REMOVED = 0x200000;
        public const uint D_EXO_API_PRINTER_STATUS_PSDW_PARCUT_PRINTOUT_TAKEN = 0x100000;
        public const uint D_EXO_API_PRINTER_STATUS_PSDW_POWER_FAILURE = 0x1000;
        public const uint D_EXO_API_PRINTER_STATUS_PSDW_PRESENTER_ACTIVE = 0x80000;
        public const uint D_EXO_API_PRINTER_STATUS_PSDW_PRESENTER_AVAILABLE = 0x40000;
        public const uint D_EXO_API_PRINTER_STATUS_PSDW_PRINT_HEAD_TEMP_ALERT = 2;
        public const uint D_EXO_API_PRINTER_STATUS_PSDW_PRINT_HEAD_UP_DETECTED = 0x100;
        public const uint D_EXO_API_PRINTER_STATUS_PSDW_PRINTER_BUSY = 0x10000;
        public const uint D_EXO_API_PRINTER_STATUS_PSDW_PRINTER_ERROR = 1;
        public const uint D_EXO_API_PRINTER_STATUS_PSDW_PRINTER_NOT_READY = 0x8000;
        public const uint D_EXO_API_PRINTER_STATUS_PSDW_PRINTER_STALLED = 8;
        public const uint D_EXO_API_PRINTER_STATUS_PSDW_SYSTEM_FAILURE = 0x800;



        const string dll = "printdll\\Exo_Api.dll";
        [DllImport(dll)]
        public static extern IntPtr Exo_Api_Pe_PrinterEnumStart();
        [DllImport(dll)]
        public static extern bool Exo_Api_Pe_PrinterEnumEnd(IntPtr hPrinterEnum);
        [DllImport(dll)]
        public static extern string Exo_Api_Pe_PrinterEnum(IntPtr hPrinterEnum, bool fReset);

        [DllImport(dll)]
        public static extern IntPtr Exo_Api_Pio_PrinterOpen(string strPrinterName, uint dwOptions, uint dwTimeOutMs);

        [DllImport(dll)]
        public static extern bool Exo_Api_Pio_PrinterClose(IntPtr hPrinter);

         [DllImport(dll)]
        public static extern bool Exo_Api_Pio_PrinterWrite(IntPtr hPrinterIo, byte[] pubData, uint nData, uint dwTimeOutMs);

        [DllImport(dll)]
        public static extern bool Exo_Api_Pio_PrinterPrintImage(IntPtr hPrinterIo, string pszImageFile, uint dwTimeOutMs);
    }
}
