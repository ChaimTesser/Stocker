﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Media;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Stocker
{
    public class RunData
    {
        //all symbols for lookup
        List<string> symb = new List<string>() { "DDD", "MMM", "WBAI", "WUBA", "EGHT", "AHC", "AOS", "ATEN", "AIR", "AAN", "ABB", "ABT", "ABBV", "ANF", "AGD", "AWP", "ACP", "JEQ", "AOD", "ABM", "AKR", "ACEL", "ACEL.WS", "ACN", "ACCO", "ATV", "AYI", "GOLF", "ADX", "PEO", "AGRO", "ADNT", "ADT", "ATGE", "AAP", "ADSW", "WMS", "ASIX", "AVK", "ACM", "AEFC", "AEB", "AEG", "AER", "AJRD", "AMG", "MGR", "AFL", "MITT", "MITT^A", "MITT^B", "MITT^C", "AGCO", "A", "AEM", "ADC", "AL", "AL^A", "APD", "ALP^Q", "ALG", "AGI", "ALK", "AIN", "ALB", "AA", "ALC", "ALEX", "ALX", "ARE", "AQN", "AQNA", "AQNB", "BABA", "Y", "ATI", "ALLE", "AGN", "ALE", "ADS", "AFB", "AWF", "AB", "AIO", "CBH", "NCV", "NCV^A", "NCZ", "NCZ^A", "ACV", "NIE", "NFJ", "ALSN", "ALL", "ALL^B", "ALL^G", "ALL^H", "ALL^I", "ALLY", "ALLY^A", "PINE", "ALTG", "ALTG.WS", "ALIN^A", "ALIN^B", "ALIN^E", "AYX", "ATUS", "MO", "ACH", "ALUS", "ALUS.U", "ALUS.WS", "AMBC", "AMBC.WS", "ABEV", "AMC", "AMCR", "AEE", "AMRC", "AMOV", "AMX", "AAT", "AXL", "ACC", "AEO", "AEP", "AEP^B", "AEL", "AEL^A", "AXP", "AFG", "AFGB", "AFGC", "AFGH", "AMH", "AMH^D", "AMH^E", "AMH^F", "AMH^G", "AMH^H", "AIG", "AIG.WS", "AIG^A", "ARL", "ARA", "AWR", "AMT", "AVD", "AWK", "COLD", "AMP", "ABC", "RYCE", "AMN", "AMRX", "AP", "APH", "AXR", "HKIB", "AME", "PLAN", "FINS", "AU", "BUD", "AXE", "NLY", "NLY^D", "NLY^F", "NLY^G", "NLY^I", "AM", "AR", "ANTM", "ANH", "ANH^A", "ANH^B", "ANH^C", "AON", "APA", "AIV", "APY", "APHA", "ARI", "APO", "APO^A", "APO^B", "AFT", "AIF", "APLE", "AIT", "ATR", "APTV", "ARMK", "ABR", "ABR^A", "ABR^B", "ABR^C", "ARC", "MT", "ARCH", "ADM", "AROC", "ARNC", "ARCO", "ACA", "RCUS", "ARD", "ASC", "AFC", "ACRE", "ARDC", "ARES", "ARES^A", "AGX", "ARGD", "ARGO", "ANET", "AI", "AI^B", "AI^C", "AIC", "AIW", "ARLO", "AHH", "AHH^A", "ARR", "ARR^C", "AFI", "AWI", "ARW", "AJG", "APAM", "ASA", "ABG", "ASX", "ASGN", "AHT", "AHT^D", "AHT^F", "AHT^G", "AHT^H", "AHT^I", "ASH", "ASPN", "AHL^C", "AHL^D", "AHL^E", "AMK", "ASB", "ASB^C", "ASB^D", "ASB^E", "AC", "AIZ", "AIZP", "AGO", "AGO^B", "AGO^E", "AGO^F", "AZN", "HOME", "T", "T^A", "T^C", "TBB", "TBC", "ATTO", "ATH", "ATH^A", "ATH^B", "ATKR", "AT", "ATCO", "ATCO^D", "ATCO^E", "ATCO^G", "ATCO^H", "ATCO^I", "ATO", "ACB", "ATHM", "ALV", "AN", "AZO", "AVLR", "AVB", "AGR", "AVNS", "AVTR", "AVTR^A", "AVYA", "AVY", "AVH", "AVA", "AXTA", "AXS", "AXS^E", "AX", "AXO", "AZUL", "AZRE", "AZZ", "BGS", "BW", "BGH", "BMI", "BCSF", "BKR", "BBN", "BLL", "BANC", "BANC^D", "BANC^E", "BBAR", "BBVA", "BBD", "BBDO", "BCH", "BLX", "BSBR", "BSAC", "BSMX", "SAN", "SAN^B", "CIB", "BXS", "BXS^A", "BAC", "BAC^A", "BAC^B", "BAC^C", "BAC^E", "BAC^K", "BAC^L", "BAC^M", "BAC^N", "BML^G", "BML^H", "BML^J", "BML^L", "BOH", "BMO", "NTB", "BNS", "BKU", "BCS", "BBDC", "MCI", "MPV", "BNED", "B", "GOLD", "BHC", "BAX", "BTE", "BBX", "BCE", "BZH", "BDX", "BDXA", "BDC", "BRBR", "BHE", "BRK.A", "BRK.B", "BHLB", "BERY", "BBY", "BEST", "BGSF", "BHP", "BBL", "BIG", "BH", "BH.A", "BILL", "BHVN", "BIO", "BIO.B", "BITA", "BJ", "BKH", "BKI", "BSM", "BB", "BGIO", "BFZ", "CII", "BHK", "HYT", "BTZ", "DSU", "BGR", "BDJ", "EGF", "FRA", "BFO", "BGT", "BOE", "BME", "BMEZ", "BAF", "BKT", "BGY", "BKN", "BTA", "BZM", "MHE", "BIT", "MUI", "MNE", "MUA", "BKK", "BBK", "BBF", "BYM", "BFK", "BLE", "BTT", "MEN", "MUC", "MUH", "MHD", "MFL", "MUJ", "MHN", "MUE", "MUS", "MVT", "MYC", "MCA", "MYD", "MYF", "MFT", "MIY", "MYJ", "MYN", "MPA", "MQT", "MYI", "MQY", "BNY", "BQH", "BSE", "BFY", "BCX", "BST", "BSTZ", "BSD", "BUI", "BHV", "BLK", "BGB", "BGX", "BSL", "BE", "APRN", "BXG", "BXC", "DCF", "DHF", "DMB", "DSM", "LEO", "BA", "BCC", "BCEI", "BOOT", "BAH", "BWA", "BORR", "SAM", "BXP", "BXP^B", "BSX", "BOX", "BYD", "BPMP", "BP", "BPT", "BRC", "BHR", "BHR^B", "BHR^D", "BDN", "BWG", "LND", "BAK", "BRFS", "BGG", "MNRL", "BFAM", "BEDU", "BSA", "BSIG", "BV", "EAT", "BCO", "BMY", "BMY~", "BTI", "BRX", "BRMK", "BR", "BKD", "BAM", "BBU", "DTLA^", "BIPC", "BIP", "RA", "BEP", "BEP^A", "BRO", "BF.A", "BF.B", "BRT", "BC", "BC^A", "BC^B", "BC^C", "BKE", "BVN", "BBW", "BG", "BURL", "BWXT", "BY", "PFH", "CABO", "CBT", "COG", "CACI", "WHD", "CADE", "CAE", "CAI", "CAI^A", "CAI^B", "CAL", "CRC", "CWT", "CALX", "ELY", "CPE", "CPT", "CCJ", "CPB", "CWH", "GOOS", "CM", "CNI", "CNQ", "CP", "CANG", "CNNE", "CAJ", "CGC", "CMD", "COF", "COF^F", "COF^G", "COF^H", "COF^I", "COF^J", "CSU", "BXMT", "CPRI", "CMO", "CMO^E", "CAH", "CSL", "KMX", "CCL", "CUK", "CRS", "CSV", "CARR", "CARS", "CRI", "CVNA", "CSPR", "CSLT", "CTLT", "CTT           ", "CAT", "CATO", "CBZ", "CBL", "CBL^D", "CBL^E", "CBO", "IGR", "CBRE", "CBX", "PCPL.U", "FUN", "CDR", "CDR^B", "CDR^C", "CE", "CLS", "CELG~", "CEL", "CPAC", "CX", "CVE", "CNC", "CEN", "CNP", "CNP^B", "EBR", "EBR.B", "CEPU", "CCS", "CTL", "CDAY", "CF", "GIB", "ECOM          ", "CHAP", "CHRA", "CRL", "CLDT", "CMCM", "CHGG", "CHE", "CC", "CHMI", "CHMI^A", "CHMI^B", "CHK", "CHK^D", "CPK", "CVX", "CHWY", "CHS", "CIM", "CIM^A", "CIM^B", "CIM^C", "CIM^D", "DL", "CEA", "CHN", "CGA", "LFC", "CHL", "COE", "SNP", "XRF", "ZNH", "CHA", "CHU", "CYD", "CMG", "CHH", "CB", "CHT", "CHD", "CCX", "CCX.U", "CCX.WS", "CCXX", "CCXX.U", "CCXX.WS", "CIEN", "CI", "XEC", "CBB", "CBB^B", "CNK", "CINR", "CIR", "CIT", "CIT^B", "CCAC", "CCAC.U", "CCAC.WS", "BLW", "C", "C^J", "C^K", "C^N", "C^S", "CFG", "CFG^D", "CFG^E", "CIA", "CIO", "CIO^A", "CVEO", "CCC", "CLH", "CCO", "EMO", "CEM", "CTR", "CLW", "CWEN", "CWEN.A", "CLF", "CLPR", "CLX", "CLDR", "NET", "CMS", "CMS^B", "CMSA", "CMSC", "CMSD", "CNA", "CNF", "CNHI", "CNO", "CEO", "CNXM", "CNX", "KOF", "KO", "CCEP", "CDE", "FOF", "CNS", "UTF", "LDP", "MIE", "RQI", "RNP", "PSF", "RFI", "CFX", "CFXA", "CL", "CCH", "CCH.U", "CCH.WS", "CXE", "CIF", "CXH", "CMU", "CLNY", "CLNY^G", "CLNY^H", "CLNY^I", "CLNY^J", "CLNC", "CXP", "STK", "CCZ", "CMA", "FIX", "CMC", "CBU", "CYH", "CHCT", "CIG", "CIG.C", "CBD", "SBS", "ELP", "CCU", "CODI", "CODI^A", "CODI^B", "CODI^C", "CMP", "CRK", "CAG", "CXO", "CCM", "CNMD", "COP", "CCR", "CEIX", "ED", "STZ", "STZ.B", "CSTM", "TCS", "CLR", "VLRS", "CTRA", "CTB", "CPS", "CTK", "CPA", "CLB", "CXW", "CLGX", "CORR", "CORR^A", "CPLG", "COR", "CNR", "GLW", "CAAP", "GYC", "OFC", "CTVA", "CZZ", "CMRE", "CMRE^B", "CMRE^C", "CMRE^D", "CMRE^E", "COTY", "CUZ", "CVA", "CVIA", "CPF", "CR", "CRD.A", "CRD.B", "BAP", "CS", "CPG", "CEQP", "CEQP^", "CRH", "CRT", "CAPL", "CCI", "CCI^A", "CCK", "CRY", "CTS", "CUBE", "CUB", "CFR", "CULP", "CMI", "CURO", "CW", "SRF", "SRV", "SZC", "CWK", "CUBB", "CUBI", "CUBI^C", "CUBI^D", "CUBI^E", "CUBI^F", "CVI", "UAN", "CVS", "CELP", "DHI", "DAN", "DHR", "DHR^A", "DAC", "DQ", "DRI", "DAR", "DVA", "DCP", "DCP^B", "DCP^C", "DECK", "DE", "DEX", "DDF", "DKL", "DK", "DELL", "DLPH", "DAL", "DLX", "DNR", "DBI", "DESP", "DB", "DXB.CL", "DVN", "DHX", "DHT", "DEO", "DO", "DSSI", "DRH", "DSX", "DSX^B", "DKS", "DBD", "DLR", "DLR^C", "DLR^G", "DLR^I", "DLR^J", "DLR^K", "DLR^L", "DDS", "DDT", "DIN", "DFS", "DNI", "DMYT", "DMYT.U", "DMYT.WS", "DLB", "DG", "D", "DCUE", "DRUA", "DPZ", "UFS", "DCI", "DFIN", "LPG", "DSL", "DBL", "DLY", "PLOW", "DEI", "DOV", "DVD", "DOW", "RDY", "DRD", "DRQ", "DS", "DS^B", "DS^C", "DS^D", "DTE", "DTJ", "DTP", "DTQ", "DTW", "DTY", "DCO", "DSE", "DNP", "DTF", "DUC", "DPG", "DUK", "DUK^A", "DUKB", "DUKH", "DRE", "DD", "DXC", "DY", "DLNG", "DLNG^A", "DLNG^B", "DT", "DX", "DX^B", "DX^C", "CTA^A", "CTA^B", "ELF", "EGIF", "EXP", "ECC           ", "ECCB", "ECCX", "ECCY", "EIC", "ESTE", "DEA", "EGP", "EMN", "KODK", "ETN", "ETV", "ETW", "EV", "EOI", "EOS", "EFT", "EFL", "EFF", "EHT", "ETX           ", "EOT", "EVN", "ETJ", "EFR", "EVF", "EVG", "EVT", "ETO", "ETG", "ETB", "EXD", "ETY", "EXG", "ECT", "ECL", "EC", "EPC", "EIX", "EW", "EP^C", "EE", "ELAN", "ELAT", "ESTC", "EGO", "ESI", "ELVT", "LLY", "EFC", "EFC^A", "EARN", "AKO.A", "AKO.B", "ERJ", "EME", "EEX", "EBS", "EMR", "ESRT", "EIG", "EDN", "ENBL", "ENB", "ENBA", "EHC", "DAVA", "EXK", "ENIA", "ENIC", "ENR", "ENR^A", "ET", "ETP^C", "ETP^D", "ETP^E", "EPAC", "ERF", "ENS", "E", "ENLC", "EBF", "ENVA", "NPO", "ETM", "EAB", "EAE", "EAI", "ETR", "ELC", "ELJ", "ELU", "EMP", "ENJ", "ENO", "ETI^", "EZT", "EPD", "EVC", "ENV", "NVST", "EVA", "ENZ", "EOG", "EPAM", "EPR", "EPR^C", "EPR^E", "EPR^G", "EQM", "EQT", "EFX", "EQNR", "EQH", "EQH^A", "ETRN", "EQC", "EQC^D", "ELS", "EQR", "EQS", "ERA", "EROS", "ESE", "ESNT", "EPRT", "WTRG", "WTRU", "ESS", "EL", "ETH", "EURN", "EEA", "EB", "EVR", "RE", "EVRG", "EVRI", "ES", "EVTC", "EVH", "AQUA", "XAN", "XAN^C", "EXPR", "EXTN", "EXR", "XOM", "FNB", "FNB^E", "FN", "FDS", "FICO", "SFUN", "FPAC", "FPAC.U", "FPAC.WS", "FTCH", "FPI", "FPI^B", "FSLY", "FBK", "FFG", "AGM", "AGM.A", "AGM^A", "AGM^C", "AGM^D", "FRT", "FRT^C", "FSS", "FHI", "FMN", "FDX", "RACE", "FOE", "FG", "FG.WS", "FCAU", "FNF", "FIS", "FMO", "FINV", "FAF", "FBP", "FCF", "FHN", "FHN^A", "FR", "AG", "FRC", "FRC^F", "FRC^G", "FRC^H", "FRC^I", "FRC^J", "FFA", "FMY", "FDEU", "FIF", "FSD", "FPF", "FEI           ", "FPL", "FIV", "FCT", "FGB", "FEO", "FAM", "FE", "FIT", "FPH", "FVRR", "FBC", "DFP", "PFD", "PFO", "FFC", "FLC", "FLT", "FLNG", "FND", "FTK", "FLO", "FLS", "FLR", "FLY", "FEAC.U", "FMC", "FMX", "FL", "F", "F^B", "F^C", "FOR", "FTS", "FTV", "FTV^A", "FTAI", "FTAI^A", "FTAI^B", "FSM", "FBHS", "FET", "FBM", "FCPT", "FEDU", "FNV", "FC", "FSB", "BEN", "FT", "FI", "FCX", "FMS", "FDP", "RESI", "FRO", "FSK", "FCN", "FTSI", "FF", "GCV", "GAB", "GAB^G", "GAB^H", "GAB^J", "GAB^K", "GGZ", "GGZ^A", "GGT", "GGT^E", "GGT^G", "GUT", "GUT^A", "GUT^C", "GCAP", "GLEO", "GLEO.U", "GLEO.WS", "GBL", "GNT", "GNT^A", "GME", "GCI", "GPS", "GTX", "IT", "GLOG", "GLOG^A", "GLOP", "GLOP^A", "GLOP^B", "GLOP^C", "GTES", "GATX", "GMTA", "GCP", "GNK", "GNRC", "GAM", "GAM^B", "GD", "GE", "GIS", "GM", "GCO", "GEL", "GEN           ", "GNE", "GNE^A", "G", "GPC", "GNW", "GEO", "GPRK", "GPJA", "GGB", "GTY", "GFL", "GFLU", "GIX", "GIX.U", "GIX.WS", "GIX~", "GIL", "GLT", "GKOS", "GSK", "CO", "GMRE", "GMRE^A", "GNL", "GNL^A", "GNL^B", "GLP", "GLP^A", "GPN", "GSL", "GSL^B", "GSLD", "GLOB", "GL", "GL^C", "GMED", "GMS", "GNC", "GDDY", "GOL", "GFI", "GSBD", "GS", "GS^A", "GS^C", "GS^D", "GS^J", "GS^K", "GS^N", "GER", "GMZ", "GRC", "GPX", "GGG", "GRAF", "GRAF.U", "GRAF.WS", "EAF", "GHM", "GHC", "GRAM", "GVA", "GPMT", "GRP.U", "GPK", "GTN", "GTN.A", "AJX", "AJXA", "GWB", "GDOT", "GBX", "GHL", "GHG", "GEF", "GEF.B", "GFF", "GPI", "GRUB", "PAC", "ASR", "AVAL", "SUPV", "TV", "GSX", "GTT", "GSH", "GES", "GGM", "GPM", "GOF", "GBAB", "GWRE", "HRB", "FUL", "HAE", "HAL", "HBB", "HBI", "HNGR", "HASI", "HOG", "HMY", "HSC", "HHS", "HGH", "HIG", "HIG^G", "HVT", "HVT.A", "HE", "HCHC", "HCA", "HCI", "HDB", "HR", "HTA", "PEAK", "HL", "HL^B", "HEI", "HEI.A", "HLX", "HP", "HLF", "HRI", "HCXY", "HCXZ", "HTGC", "HRTG", "PSV", "HT", "HT^C", "HT^D", "HT^E", "HSY", "HTZ", "HES", "HESM", "HPE", "HXL", "HEXO", "HCR", "PCF", "HGLB", "HFRO", "HFRO^A", "HPR", "HIW", "HIL", "HI", "HRC", "HTH", "HGV", "HLT", "HNI", "HMLP", "HMLP^A", "HEP", "HFC", "HD", "HMC", "HON", "HMN", "HZN", "HTFA", "HRL", "HST", "HLI", "HOV", "HHC", "HWM", "HPQ", "HSBC", "HSBC^A", "HMI", "HNP", "HUBB", "HUBS", "HBM", "HUD", "HPP", "HUM", "HCFT", "HII", "HUN", "HUYA", "H", "HY", "IAA", "IAG", "IBN", "IDA", "IEX", "IDT", "INFO", "ITW", "IMAX", "ICD", "IHC", "IRT", "IFN", "IBA", "INFY", "ING", "IR", "NGVT", "INGR", "IIPR", "IIPR^A", "IPHI", "INSI", "NSP", "INSP", "IBP", "ITGR", "I", "ICE", "IHG", "IFS", "IBM", "IFF", "IFFT", "IGT", "IP", "INSW", "INSW^A", "IPV", "IPV.U", "IPV.WS", "IPG", "IPI", "IVC", "VBF", "VCV", "VTA", "IHIT", "IHTA", "VLT", "IVR", "IVR^B", "IVR^C", "IVR^A", "OIA", "VMO", "VKQ", "VPV", "IVZ", "IQI", "VVR", "VTN", "VGM", "IIM", "IRET", "IRET^C", "NVTA", "INVH", "IO", "IQV", "IRM", "IRS", "ICL", "STAR          ", "STAR^D", "STAR^G", "STAR^I", "ITCB", "ITUB", "ITT", "IVH", "JPM", "JPM^C", "JPM^D", "JPM^G", "JPM^H", "JPM^J", "JAX", "JILL", "JCP", "SJM", "JBL", "J", "JHX", "JHG", "JOF", "JBGS", "JEF", "JELD", "JCAP", "JCAP^B", "JT", "JKS", "JMP", "JBT", "BTO", "HEQ", "JHS", "JHI", "HPF", "HPI", "HPS", "PDT", "HTD", "HTY", "JW.A", "JW.B", "JNJ", "JCI", "JLL", "JMIA", "JIH", "JIH.U", "JIH.WS", "JNPR", "JP", "JE", "JE^A", "LRN", "KAI", "KDMN", "KAMN", "KSU", "KSU^", "KAR", "KMF", "KYN", "KB", "KBH", "KBR", "K", "KEM", "KMPR", "KMT", "KW", "KEN", "KDP", "KEY", "KEY^I", "KEY^J", "KEY^K", "KEYS", "KRC", "KRP", "KMB", "KIM", "KIM^L", "KIM^M", "KMI", "KFS", "KGC", "KEX", "KL", "KRG", "KKR", "KKR^A", "KKR^B", "KIO", "KREF", "KNX", "KNL", "KNOP", "KN", "KSS", "PHG", "KTB", "KOP", "KEP", "KF", "KFY", "KOS", "KRA", "KR", "KRO", "KT", "LB", "SCX", "LHX", "LH", "LADR", "LAIX", "LW", "LCI", "LPI", "LVS", "LTM", "LGI", "LAZ", "LZB", "LCII", "LEAF", "LEA", "LEE", "LGC", "LGC.U", "LGC.WS", "LM", "LMHA", "LMHB", "LEG", "JBK", "KTH", "KTN", "KTP", "LDOS", "LEJU", "LC", "LEN", "LEN.B", "LII", "LHC", "LHC.U", "LHC.WS", "LEVI", "LXP", "LXP^C", "LPL", "DFNS", "DFNS.U", "DFNS.WS", "USA", "ASG", "LBRT", "LSI", "LITB", "LNC", "LIN", "LNN", "LN", "LINX", "LGF.A", "LGF.B", "LAD", "LAC", "LYV", "LTHM", "RAMP", "LYG", "SCD", "LMT", "L", "LOMA", "LPX", "LOW", "LXU", "LTC", "LUB", "LL", "LXFR", "LDL", "LYB", "MTB", "MDC", "MHO", "MAC", "CLI", "MFD", "MGU", "MIC", "BMA", "M", "MCN", "MSGE", "MSGS", "MMP", "MGA", "MX", "MGY", "MH^A", "MH^C", "MH^D", "MHLA", "MHNC", "MAIN", "MMD", "MNK", "MANU", "MTW", "MN", "MAN", "MFC", "MRO", "MPC", "MMI", "MCS", "MPX", "HZO", "MKL", "VAC", "MMC", "MLM", "MAS", "DOOR", "MTZ", "MA", "MTDR", "MTRN", "MATX", "MLP", "MAXR", "MMS", "MXL", "MEC", "MBI", "MKC", "MKC.V", "MCD", "MUX", "MCK", "MDU", "MTL", "MTL^", "MDLA", "MPW", "MED", "MCC", "MCV", "MCX", "MDLQ", "MDLX", "MDLY", "MD", "MDT", "MFAC", "MFAC.U", "MFAC.WS", "MRK", "MCY", "MDP", "MTH", "MTOR", "MER^K", "PIY", "MTR", "MSB", "MEI", "MET", "MET^A", "MET^E", "MET^F", "MCB", "MTD", "MXE", "MXF", "MFA", "MFA^B", "MFA^C", "MFO", "MCR", "MGF", "MIN", "MMT", "MFM", "MFV", "MTG", "MGP", "MGM", "MFGP", "MAA", "MAA^I", "AMPY", "MLR", "HIE", "MTX", "MG", "MUFG", "MIXT", "MFG", "MBT", "MODN", "MOD", "MC", "MOGU", "MHK", "MOH", "TAP", "TAP.A", "MNR", "MNR^C", "MR", "MCO", "MOG.A", "MOG.B", "MS", "MS^A", "MS^E", "MS^F", "MS^I", "MS^K", "MS^L", "CAF", "MSD", "EDD", "IIF", "MOS", "MSI", "MOV", "MPLX", "MRC", "HJV", "MSA", "MSM", "MSCI", "MSGN", "MLI", "MWA", "MVF", "MZA", "MUR", "MUSA", "MVO", "MVC", "MVCD", "MYE", "MYOV", "NBR", "NBR^A", "NC", "NTP", "NTEST", "NTEST.A", "NTEST.B", "NTEST.C", "NBHC", "NFG", "NGG", "NHI", "NOV", "NPK", "NNN", "NNN^F", "NRUC", "SID", "NSA", "NSA^A", "NTCO", "NGS", "NGVC", "NRP", "NTZ", "NLS", "NVGS", "NNA", "NM", "NM^G", "NM^H", "NMM", "NAV", "NAV^D", "NCR", "NP", "NNI", "NPTN", "NSCO", "NSCO.WS", "NVRO", "HYB", "NFH", "NFH.WS", "GF", "NWHM", "IRL", "NMFC", "NMFX", "EDU", "NEWR", "NRZ", "NRZ^A", "NRZ^B", "NRZ^C", "SNR", "NYCB", "NYCB^A", "NYCB^U", "NYT", "NJR", "NEU", "NEM", "NR", "NEXA", "NREF", "NXRT", "NHF", "NEP", "NEE", "NEE^I", "NEE^J", "NEE^K", "NEE^N", "NEE^O", "NEE^P", "NEX", "NGL", "NGL^B", "NGL^C", "NMK^B", "NMK^C", "NLSN", "NKE", "NINE", "NIO", "NI", "NI^B", "NL", "NOAH", "NE", "NOK", "NOMD", "NMR", "OSB", "NAT", "JWN", "NSC", "NOA", "NRT", "NOC", "NWN", "NWE", "NCLH", "NVS", "NVO", "DNOW", "NRG", "NUS", "NUE", "NS", "NS^A", "NS^B", "NS^C", "NSS", "NTR", "JMLP", "NVG", "NUV", "NUW", "NEA", "NAZ", "NKX", "NCB", "NCA", "NAC", "JCE", "JCO", "JQC", "JDD", "DIAX", "JEMD", "JMF", "NEV", "JFR", "JRO", "NKG", "JGH", "JHY", "JHAA", "JHB", "NXC", "NXN", "NID", "NMY", "NMT", "NUM", "NMS", "NOM", "JLS", "JMM", "NHA", "NZF", "NMCO", "NMZ", "NMI", "NJV", "NXJ", "NRK", "NYV", "NNY", "NAN", "NUO", "NPN", "NQP", "JPC", "JPS", "JPT", "JPI", "NAD", "JRI", "JRS", "BXMX", "SPXX", "NIM", "NXP", "NXQ", "NXR", "NSL", "JSD", "NBB", "JTD", "JTA", "NPV", "NIQ", "NVT", "NVR", "CTEST", "CTEST.E", "CTEST.G", "CTEST.L", "CTEST.O", "CTEST.S", "CTEST.V", "OAC", "OAC.U", "OAC.WS", "OAK^A", "OAK^B", "OXY", "OII", "OCN", "OFG", "OFG^A", "OFG^B", "OFG^D", "OGE", "OI", "OIBR.C", "OIS", "ODC", "ORI", "OLN", "OHI", "OMC", "ONDK", "OGS", "OLP", "OCFT", "OMF", "OKE", "ONE", "ONTO", "OOMA", "OPY", "ORCL", "ORAN", "ORC", "OEC", "ORN", "IX", "ORA", "OSK", "OR", "SFTW", "SFTW.U", "SFTW.WS", "OTIS", "OUT", "OSG", "OVV", "OMI", "OC", "ORCC", "OXM", "ROYT", "PACD", "PCG", "PKG", "PD", "PAGS", "PANW", "PAM", "PHX", "PARR", "PAR", "PGRE", "PKE", "PK", "PH", "PE", "PSN", "PRE^F", "PRE^G", "PRE^H", "PRE^I", "PRTY", "PAYC", "PBF", "PBFX", "BTU", "PSO", "PEB", "PEB^C", "PEB^D", "PEB^E", "PEB^F", "PBA", "PEI", "PEI^B", "PEI^C", "PEI^D", "PFSI", "PMT", "PMT^A", "PMT^B", "PAG", "PNR", "PEN", "PFGC", "PKI", "PBT", "PVL", "PRT", "PRGO", "PRSP", "PTR", "PBR", "PBR.A", "PFE", "GHY", "ISD", "PGTI", "PM", "PSX", "PSXP", "FENG", "DNK", "PHR", "DOC", "PDM", "PCQ", "PCK", "PZC", "PCM", "PTY", "PCN", "PCI", "PDI", "NRGX", "PGP", "PHK", "PKO", "PFL", "PFN", "PMF", "PML", "PMX", "PNF", "PNI", "PYN", "RCS", "PING", "PNW", "PINS", "PHD", "PHT", "MAV", "MHI", "PXD", "PIPR", "PBI", "PBI^B", "PIC", "PIC.U", "PIC.WS", "PJT", "PAA", "PAGP", "PLNT", "PLT", "AGS", "PHI", "PLYM", "PNC", "PNC^P", "PNC^Q", "PNM", "PII", "POL", "POR", "PKX", "POST", "PSTL", "PPG", "PPX", "PPL", "PYS", "PYT", "PQG", "PDS", "APTS", "PBH", "PVG", "PRI", "PRMW", "PGZ", "PRIF^A", "PRIF^B", "PRIF^C", "PRIF^D", "PRIF^E", "PRIF^F", "PRA", "PG", "PGR", "PLD", "PUMP", "PRO", "PROS", "PBB", "PBC", "PBY", "PB", "PRLB", "PFS", "PJH", "PRH", "PRS", "PRU", "PUK", "PUK^", "PUK^A", "PSB", "PSB^W", "PSB^X", "PSB^Y", "PSB^Z", "TLK", "PEG", "PSA", "PSA^B", "PSA^C", "PSA^D", "PSA^E", "PSA^F", "PSA^G", "PSA^H", "PSA^I", "PSA^J", "PSA^K", "PSA^V", "PSA^W", "PSA^X", "PHM", "PSTG", "PMM", "PIM", "PMO", "PPT", "NEW", "PVH", "PYX", "PZN", "QTWO", "QEP", "QGEN", "QTS", "QTS^A", "QTS^B", "QUAD", "KWR", "NX", "PWR", "QD", "DGX", "QES", "QUOT", "QVCC", "QVCD", "CTAA", "CTBB", "CTDD", "CTV", "CTY", "CTZ", "RRD", "RMED", "RDN", "RFL", "RL", "RRC", "RNGR", "PACK", "PACK.WS", "RJF", "RYAM", "RYN", "RTX", "RMAX", "RC", "RCA", "RCB", "RCP", "RLGY", "O", "RLH", "RWT", "RBC", "RM", "RF", "RF^A", "RF^B", "RF^C", "RGS", "RGA", "RZA", "RZB", "RS", "RELX", "RNR", "RNR^E", "RNR^F", "SOL", "RENN", "RPLA", "RPLA.U", "RPLA.WS", "RSG", "REZI", "RMD", "RFP", "QSR", "RPAI", "RVI", "REVG", "REV", "RVLV", "REX", "REXR", "REXR^A", "REXR^B", "REXR^C", "RXN", "RH", "RNG", "RIO", "RBA", "RAD", "RFM", "RMM", "RMI", "RIV", "RMPL^", "RSF", "OPP", "RLI", "RLJ", "RLJ^A", "RMG", "RMG.U", "RMG.WS", "RHI", "ROK", "RCI", "ROG", "ROL", "ROP", "RST", "RY", "RY^T", "RBS", "RCL", "RDS.A", "RDS.B", "RGT", "RMT", "RVT", "RES", "RPM", "RPT", "RPT^D", "RTW", "RYB", "R", "RYI", "RHP", "SPGI", "SBR", "SB", "SB^C", "SB^D", "SFE", "SAFE", "SAIL", "CRM", "SMM", "SBH", "SJT", "SD", "PER", "SAND          ", "SC", "SAP", "SAF", "SAR", "SSL", "BFS", "BFS^D", "BFS^E", "SCPE", "SCPE.U", "SCPE.WS", "SLB", "SNDR", "SWM", "SAIC", "SALT", "SBNA", "STNG", "SMG", "KTF", "KSM", "SRL", "SCU", "SCVX", "SCVX.U", "SCVX.WS", "SE", "SA", "CKH", "SMHI", "SDRL", "SEE", "SEAS", "JBN", "JBR", "WTTR", "SEM", "SRE", "SRE^A", "SRE^B", "SREA", "ST", "SXT", "SQNS", "SRG", "SRG^A", "SCI", "SERV", "NOW", "SFL", "SHAK", "SJR", "SHLX", "SHW", "SHG", "SHOP", "SSTK", "SBSW", "SIG", "SBOW", "SI", "SPG", "SPG^J", "SSD", "SHI", "SITC", "SITC^A", "SITC^K", "SITE", "SIX", "SJW", "SKM", "SKX", "SKY", "SLG", "SLG^I", "WORK", "SM", "SMAR", "SNN", "SNAP", "SNA", "IPOC.U", "SQM", "SOGO", "SOI", "SWI", "SAH", "SON", "SNE", "SOR", "SJI", "SJIJ", "SJIU", "SCE^G", "SCE^H", "SCE^J", "SCE^K", "SCE^L", "SO", "SOJA", "SOJB", "SOJC", "SOJD", "SOLN", "SCCO", "LUV", "SWX", "SWN", "SPAQ", "SPAQ.U", "SPAQ.WS", "SPE", "SPE^B", "SPB           ", "SR", "SR^A", "SPR", "SAVE", "SRC", "SRC^A", "SPOT", "SRLP", "SPXC", "FLOW", "SQ", "JOE", "STAG", "STAG^C", "SSI", "SMP", "SXI", "SWK", "SWP", "SWT", "STN", "SGU", "SRT", "STWD", "STT", "STT^D", "STT^G", "SPLP", "SPLP^A", "SCS", "SCA", "SCM", "SCL", "STE", "STL", "STL^A", "STC", "SF", "SF^A", "SF^B", "SFB", "STM", "EDF", "EDI", "STON", "SRI", "STOR", "GJH", "GJO", "GJS", "SYK", "MSC", "RGR", "SPH", "SMFG", "INN", "INN^D", "INN^E", "SUM", "SMLP", "SUI", "SLF", "SXC", "SU", "STG", "NOVA", "SUN", "SHO", "SHO^E", "SHO^F", "SPN", "SUP", "SUZ", "SWZ", "SWCH", "SBE", "SBE.U", "SBE.WS", "SYF", "SYF^A", "SNX", "SNV", "SNV^D", "SNV^E", "GJP", "GJR", "GJT", "SYY", "SYX", "TLRD", "TWN", "TSM", "TAK", "TAL", "TALO", "SKT", "TPR", "NGLS^A", "TRGP", "TGT", "TARO", "TTM", "TCO", "TCO^J", "TCO^K", "TMHC", "TRP", "TCP", "TSI", "TEL", "TISI", "FTI", "TECK", "TK", "TGP", "TGP^A", "TGP^B", "TNK", "TGNA", "TRC", "HQH", "THQ", "HQL", "THW", "TDOC", "TEO", "TDY", "TFX", "VIV", "TEF", "TDA", "TDE", "TDI", "TDJ", "TDS", "TU", "TDF", "EMF", "TEI", "GIM", "TPX", "TS", "TME", "THC", "TNC", "TEN", "TVC", "TVE", "TDC", "TEX", "TX", "TRNO", "TTI", "TEVA", "TPL", "TGH", "TXT", "TFII", "AES", "BK", "BK^C", "BX", "CEE", "SCHW", "SCHW^C", "SCHW^D", "COO", "GDV", "GDV^A", "GDV^G", "GDV^H", "GRX", "GRX^B", "GDL", "GDL^C", "THG", "THGA", "RUBI", "TRV", "VAM", "TMO", "THR", "TPRE", "TSLF", "TCRW", "TCRZ", "TRI", "THO", "TDW", "TDW.WS.A", "TDW.WS.B", "TIF", "TLYS", "TSU", "TKR", "TMST", "TWI", "TJX", "TOL", "TR", "BLD", "TTC", "TD", "SHLL", "SHLL.U", "SHLL.WS", "NDP", "TYG", "TEAF", "NTG", "TTP", "TPZ", "TOT", "TSQ", "TM", "TRTX", "TSLX", "TT", "TAC", "TCI", "TDG", "RIG", "TGS", "TRU", "TREC", "TG", "THS", "TREX", "TY", "TY^", "TPH", "TRNE", "TRNE.U", "TRNE.WS", "TNET", "TRN", "TSE", "TPVG", "TPVY", "GTS", "TRTN", "TRTN^A", "TRTN^B", "TRTN^C", "TRTN^D", "TGI", "TROX", "TBI", "TFC", "TFC^F", "TFC^G", "TFC^H", "TFC^I", "TNP", "TNP^C", "TNP^D", "TNP^E", "TNP^F", "TUFN", "TUP", "TKC", "TPB", "TRQ", "TPC", "TWLO", "TRWH", "TWTR", "TWO", "TWO^A", "TWO^B", "TWO^C", "TWO^D", "TWO^E", "TYL", "TSN", "USB", "USB^A", "USB^H", "USB^M", "USB^O", "USB^P", "USPH", "SLCA", "USX", "UBER", "UI", "UBS", "UDR", "UGI", "UGP", "UMH", "UMH^B", "UMH^C", "UMH^D", "UA", "UAA", "UFI", "UNF", "UN", "UL", "UNP", "UIS", "UNT", "UMC", "UNFI", "UPS", "URI", "USM", "UZA", "UZB", "UZC", "X", "UNH", "UTL", "UNVR", "UVV", "UHT", "UHS", "UVE", "UTI", "UNM", "UNMA", "UE", "UBA", "UBP", "UBP^H", "UBP^K", "USFD", "USAC", "USNA", "USDP", "BIF", "VFC", "EGY", "MTN", "VAL", "VALE", "VLO", "VHI", "VMI", "VVV", "VAPO", "VAR", "VGR", "VEC", "VEDL", "VEEV", "VEL", "VNTR", "VTR", "VNE", "VER", "VER^F", "VRTV", "VZ", "VET", "VRS", "VCIF", "VERT.U", "VRT", "VRT.WS", "VVI", "VICI", "VNCE", "VIPS", "SPCE", "VGI", "ZTR", "V", "VSH", "VPG", "VIST", "VSTO", "VST", "VST.WS.A", "VVNT", "VVNT.WS", "VSLR", "VMW", "VOC", "VCRA", "VNO", "VNO^K", "VNO^L", "VNO^M", "VJET", "IAE", "IHD", "VOYA", "VOYA^B", "IGA", "IGD", "IDE", "IID", "IRR", "PPR", "VMC", "WTI", "WPC", "WRB", "WRB^B", "WRB^C", "WRB^D", "WRB^E", "WRB^F", "GRA", "GWW", "WNC", "WBC", "WDR", "WD", "WMT", "DIS", "HCC", "WPG", "WPG^H", "WPG^I", "WRE", "WCN", "WM", "WAT", "WSO", "WSO.B", "WTS", "W", "WBS", "WBS^F", "WEC", "WEI", "WRI", "WMK", "WBT", "WFC", "WFC^L", "WFC^N", "WFC^O", "WFC^P", "WFC^Q", "WFC^R", "WFC^T", "WFC^V", "WFC^W", "WFC^X", "WFC^Y", "WFC^Z", "EOD", "WELL", "WCC", "WST", "WAL", "WALA", "WEA", "TLI", "EMD", "GDO", "EHI", "HIX", "HIO", "HYI", "SBI", "IGI", "PAI", "MMU", "WMC", "DMO", "MTT", "MHF", "MNP", "GFY", "WIW", "WIA", "WES", "WU", "WAB", "WLK", "WLKP", "WBK", "WRK", "WHG", "WEX", "WY", "WPM", "WHR", "WTM", "WSR", "WLL", "WOW", "WMB", "WSM", "WGO", "WIT", "WNS", "WWW", "WF", "WK", "INT", "WWE", "WOR", "WPP", "WPX", "WYND", "WH", "XYF", "XFLT", "XHR", "XRX", "XIN", "XPO", "XYL", "AUY", "YELP", "YETI", "YEXT", "YRD", "DAO", "YPF", "YUMC", "YUM", "ZEN", "ZBH", "ZTS", "ZTO", "ZUO", "ZYME" };

        private string key = "";

        double startBal = 1000.0;
        double profit = 0.0;
        bool _pctOnly;

        List<DateStructure> Buys = new List<DateStructure>();
        List<DateStructure> Sells = new List<DateStructure>();
        List<DateStructure> Owned = new List<DateStructure>();
        List<Balance> Balances = new List<Balance>();
        List<StockHist> AllStockHistory = new List<StockHist>();

        List<string> log = new List<string>();

        double _change = 0.0;
        double _high;
        double _drop;
        public void Run(DateTime startDate, DateTime endDate, double change, double high, double drop, bool pctOnly = false)
        {
            _pctOnly = pctOnly;
            _high = high;
            _drop = drop;
            _change = change;

            try
            {
                // set years to sample
                var years = new List<string> { startDate.Year.ToString()};
                if (startDate.Year != endDate.Year)
                {
                    var end = endDate.Year;
                    while(end != startDate.Year)
                    {
                        years.Add(end.ToString());
                        end--;
                    }
                }
                var count = 0;
                var added = new List<string>();
                foreach (var year in years)
                {
                    using (var reader = new StreamReader($@"C:\temp\{year}.csv"))
                    {
                        while (!reader.EndOfStream)
                        {
                            StockHist st = new StockHist();
                            var line = reader.ReadLine();
                            var values = line.Split(',');
                            st.Date = DateTime.Parse(values[0]);
                            st.Symbol = values[1];
                            st.Open = Double.Parse(values[2]);
                            st.High = Double.Parse(values[3]);
                            st.Low = Double.Parse(values[4]);
                            st.Close = Double.Parse(values[5]);
                            if(st.Date.Date >= startDate)
                                AllStockHistory.Add(st);
                        }
                    }
                }

                var stocksInRange = AllStockHistory.Where(a => a.Open <= _high);
                foreach (var s in stocksInRange)
                {
                    if (!added.Contains(s.Symbol))
                        Lookup(s.Symbol, count++, stocksInRange.Count());
                    added.Add(s.Symbol);
                }

                if (_pctOnly)
                    File.WriteAllLines(Path.Combine("c:\\temp", "pct.csv"), log);
                else
                {
                    Buy(startBal, Buys.OrderBy(b => b.Date).First().Date);
                    foreach (var s in Sells.OrderBy(s => s.SellDate))
                    {
                        Buy(Sell(s), s.SellDate);
                    }

                    var rep = new List<string>();
                    foreach (var b in Balances)
                    {
                        rep.Add(
                            $"{b.Date}," +
                            $"{b.Inv}," +
                            $"{b.Int}," +
                            $"{b.Inv + b.Int}"
                            );
                    }
                    File.WriteAllLines(Path.Combine("c:\\temp", startDate.ToString("ddMMyyyy") + "-" + endDate.ToString("ddMMyyyy") + "-1000-shigh-" + _high + "-Change" + _change + "drop-" + _drop + ".csv"), rep);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void Lookup(string s, int cnt, int t)
        {
            var StockHistory = AllStockHistory.Where(st => st.Symbol == s).OrderBy(x => x.Date).ToArray();

            foreach (var sh in StockHistory.Where(x => x.Open <= _high))
            {
                Console.Write("\r Loading " + cnt + "/" + t);
                var pchange = (sh.Close - sh.Open) / sh.Open;
                if (pchange <= _drop)
                {
                    var nextIndex = Array.IndexOf(StockHistory, sh) + 1;

                    //if (nextIndex < StockHistory.Length && nextIndex + 1 < StockHistory.Length)
                    //{
                    //    var next = StockHistory[nextIndex];
                    //    // var next2 = StockHistory[nextIndex + 1];
                    //    //    var next3 = StockHistory[nextIndex + 2];
                    //    log.Add(
                    //    $"{sh.Date.Date}," +
                    //    $"{(next.High - sh.Close) / next.Close}"
                    //    );
                    //}
                    if (nextIndex < StockHistory.Length && nextIndex + 1 < StockHistory.Length)
                    {
                        var next = StockHistory[nextIndex];
                        var next2 = StockHistory[nextIndex + 1];
                        var dt = new DateTime();

                        var cng = (next.High - sh.Close) / next.Close;

                        if (_pctOnly)
                        {
                            log.Add(
                                $"{sh.Date.Date}," +
                                $"{cng}"
                                );
                        }
                        else
                        {
                            var sell = 0.0;

                            if (cng >= _change)
                            {
                                dt = next.Date.DateTime;
                                sell = sh.Close + ((sh.Close / 100) * (_change * 100));
                            }
                            else if (((next2.High - sh.Close) / next2.Close) >= _change)
                            {
                                dt = next2.Date.DateTime;
                                sell = sh.Close + ((sh.Close / 100) * (_change * 100));
                            }
                            else
                            {
                                dt = next2.Date.DateTime;
                                sell = next2.Close;
                            }
                            if (Buys.SingleOrDefault(b => b.Date == sh.Date) == null)
                                Buys.Add(new DateStructure() { Date = sh.Date, SellDate = dt, StockAndPrices = new List<StockAndPrice>() { new StockAndPrice() { Stock = s, Price = sh.Close } } });
                            else
                                Buys.SingleOrDefault(b => b.Date == sh.Date).StockAndPrices.Add(new StockAndPrice() { Stock = s, Price = sh.Close });
                            if (Sells.SingleOrDefault(b => b.BoughtDate == sh.Date) == null)
                                Sells.Add(new DateStructure() { SellDate = dt, BoughtDate = sh.Date, StockAndPrices = new List<StockAndPrice>() { new StockAndPrice() { Stock = s, Price = sell } } });
                            else
                                Sells.SingleOrDefault(b => b.BoughtDate == sh.Date).StockAndPrices.Add(new StockAndPrice() { Stock = s, Price = sell });
                        }
                    }
                }
            }
            
        }
    

        public void Buy(double bal, DateTimeOffset date)
        {
            var availDates = Buys.Where(b => b.Date >= date );
            if(availDates.Count() > 0 && bal != 0)
            {
                //Price for bought = Quantity
                var buys = availDates.OrderBy(b => b.Date).First();
                var buyDate = buys.Date;
                var bought = new DateStructure { Date = buyDate, StockAndPrices = new List<StockAndPrice>() };
                var stop = false;
                while (!stop)
                {
                    foreach (var s in buys.StockAndPrices)
                    {
                        if (bal >= s.Price)
                        {
                            if (bought.StockAndPrices.SingleOrDefault(x => x.Stock == s.Stock) == null)
                                bought.StockAndPrices.Add(new StockAndPrice { Stock = s.Stock, Price = 1 });
                            else
                                bought.StockAndPrices.SingleOrDefault(x => x.Stock == s.Stock).Price++;
                            bal -= s.Price;
                        }
                        else
                            stop = true;
                    }
                }
                Owned.Add(bought);
            }
        }
        public double Sell(DateStructure sell)
        {
            double bal = 0.0;
            if (Owned.Where(o => o.Date == sell.BoughtDate).Count() > 0)
            {
                foreach (var s in sell.StockAndPrices)
                {
                    bal += Owned.Where(o => o.Date == sell.BoughtDate).SelectMany(z=>z.StockAndPrices).Where(x => x.Stock == s.Stock).Select(p=>p.Price).Sum() * sell.StockAndPrices.Single(x => x.Stock == s.Stock).Price;
                }

                var prof = 0.0;
                if (bal > startBal)
                    prof = bal - startBal;
                profit += prof;
                bal -= prof;
                if (Balances.SingleOrDefault(b => b.Date == sell.SellDate) == null)
                    Balances.Add(new Balance { Date = sell.SellDate.DateTime, Inv = bal, Int = profit });
                else
                {
                    Balances.SingleOrDefault(b => b.Date == sell.SellDate).Inv += bal;
                    Balances.SingleOrDefault(b => b.Date == sell.SellDate).Int = profit;
                }
            }
            return bal;
        }
        //Load all stock history from Tiingo API
        public async void LoadData()
        {
            Console.Write("Enter year to load:");
            var year = Console.ReadLine();
            var c = 0;
            List<string> log = new List<string>();
           
            foreach (var s in symb)
            { HttpClient _httpClient = new HttpClient();
                c++;
                Console.Write("\r" + c + "/" + symb.Count());
                _httpClient.BaseAddress = new Uri("https://api.tiingo.com/tiingo/daily/" + s + "/prices?startDate="+year+"-1-1&endDate="+ (Int32.Parse(year) + 1) +"-1-1&token=" + key);
                _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var tmp = _httpClient.GetAsync(_httpClient.BaseAddress).Result;
                string ret = "";
                if (tmp.IsSuccessStatusCode)
                {
                    ret = await tmp.Content.ReadAsStringAsync();
                    var stk = StockHist.FromJson(ret);
                    foreach (var st in stk)
                    {
                        log.Add(
                            $"{st.Date.DateTime.ToString()}," +
                            $"{s}," +
                            $"{st.Open}," +
                            $"{st.High}," +
                            $"{st.Low}," +
                            $"{st.Close}"
                            );
                    }
                }
                
            }File.WriteAllLines(Path.Combine("c:\\temp", year + ".csv"), log);
        }
    }
}
