﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC.Questionnaire
{
    //
    // Nancy.MimeTypes
    //
    // Authors:
    //	Gonzalo Paniagua Javier (gonzalo@ximian.com)
    //
    // (C) 2002 Ximian, Inc (http://www.ximian.com)
    // (C) 2003-2009 Novell, Inc (http://novell.com)

    //
    // Permission is hereby granted, free of charge, to any person obtaining
    // a copy of this software and associated documentation files (the
    // "Software"), to deal in the Software without restriction, including
    // without limitation the rights to use, copy, modify, merge, publish,
    // distribute, sublicense, and/or sell copies of the Software, and to
    // permit persons to whom the Software is furnished to do so, subject to
    // the following conditions:
    // 
    // The above copyright notice and this permission notice shall be
    // included in all copies or substantial portions of the Software.
    // 
    // THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
    // EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
    // MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
    // NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE
    // LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION
    // OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION
    // WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
    //
    public sealed class MimeTypes
    {
        static readonly Dictionary<string, string> Types;

        static MimeTypes()
        {
            Types = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
            Types.Add("323", "text/h323");
            Types.Add("3dmf", "x-world/x-3dmf");
            Types.Add("3dm", "x-world/x-3dmf");
            Types.Add("7z", "application/x-7z-compressed");
            Types.Add("aab", "application/x-authorware-bin");
            Types.Add("aam", "application/x-authorware-map");
            Types.Add("aas", "application/x-authorware-seg");
            Types.Add("abc", "text/vnd.abc");
            Types.Add("acgi", "text/html");
            Types.Add("acx", "application/internet-property-stream");
            Types.Add("afl", "video/animaflex");
            Types.Add("ai", "application/postscript");
            Types.Add("aif", "audio/aiff");
            Types.Add("aifc", "audio/aiff");
            Types.Add("aiff", "audio/aiff");
            Types.Add("aim", "application/x-aim");
            Types.Add("aip", "text/x-audiosoft-intra");
            Types.Add("ani", "application/x-navi-animation");
            Types.Add("aos", "application/x-nokia-9000-communicator-add-on-software");
            Types.Add("application", "application/x-ms-application");
            Types.Add("aps", "application/mime");
            Types.Add("art", "image/x-jg");
            Types.Add("asf", "video/x-ms-asf");
            Types.Add("asm", "text/x-asm");
            Types.Add("asp", "text/asp");
            Types.Add("asr", "video/x-ms-asf");
            Types.Add("asx", "application/x-mplayer2");
            Types.Add("atom", "application/atom.xml");
            Types.Add("atomcat", "application/atomcat+xml");
            Types.Add("atomsvc", "application/atomsvc+xml");
            Types.Add("au", "audio/x-au");
            Types.Add("avi", "video/avi");
            Types.Add("avs", "video/avs-video");
            Types.Add("axs", "application/olescript");
            Types.Add("bas", "text/plain");
            Types.Add("bcpio", "application/x-bcpio");
            Types.Add("bin", "application/octet-stream");
            Types.Add("bm", "image/bmp");
            Types.Add("bmp", "image/bmp");
            Types.Add("boo", "application/book");
            Types.Add("book", "application/book");
            Types.Add("boz", "application/x-bzip2");
            Types.Add("bsh", "application/x-bsh");
            Types.Add("bz2", "application/x-bzip2");
            Types.Add("bz", "application/x-bzip");
            Types.Add("cat", "application/vnd.ms-pki.seccat");
            Types.Add("ccad", "application/clariscad");
            Types.Add("cco", "application/x-cocoa");
            Types.Add("cc", "text/plain");
            Types.Add("cdf", "application/cdf");
            Types.Add("cer", "application/pkix-cert");
            Types.Add("cha", "application/x-chat");
            Types.Add("chat", "application/x-chat");
            Types.Add("class", "application/java");
            Types.Add("clp", "application/x-msclip");
            Types.Add("cmx", "image/x-cmx");
            Types.Add("cod", "image/cis-cod");
            Types.Add("conf", "text/plain");
            Types.Add("cpio", "application/x-cpio");
            Types.Add("cpp", "text/plain");
            Types.Add("cpt", "application/x-cpt");
            Types.Add("crd", "application/x-mscardfile");
            Types.Add("crl", "application/pkix-crl");
            Types.Add("crt", "application/pkix-cert");
            Types.Add("csh", "application/x-csh");
            Types.Add("css", "text/css");
            Types.Add("c", "text/plain");
            Types.Add("c++", "text/plain");
            Types.Add("cs", "text/plain");
            Types.Add("cxx", "text/plain");
            Types.Add("dcr", "application/x-director");
            Types.Add("deepv", "application/x-deepv");
            Types.Add("def", "text/plain");
            Types.Add("deploy", "application/octet-stream");
            Types.Add("der", "application/x-x509-ca-cert");
            Types.Add("dib", "image/bmp");
            Types.Add("dif", "video/x-dv");
            Types.Add("dir", "application/x-director");
            Types.Add("disco", "application/xml");
            Types.Add("dll", "application/x-msdownload");
            Types.Add("dl", "video/dl");
            Types.Add("doc", "application/msword");
            Types.Add("dot", "application/msword");
            Types.Add("dp", "application/commonground");
            Types.Add("drw", "application/drafting");
            Types.Add("dvi", "application/x-dvi");
            Types.Add("dv", "video/x-dv");
            Types.Add("dwf", "drawing/x-dwf (old)");
            Types.Add("dwg", "application/acad");
            Types.Add("dxf", "application/dxf");
            Types.Add("dxr", "application/x-director");
            Types.Add("elc", "application/x-elc");
            Types.Add("el", "text/x-script.elisp");
            Types.Add("eml", "message/rfc822");
            Types.Add("eot", "application/vnd.bw-fontobject");
            Types.Add("eps", "application/postscript");
            Types.Add("es", "application/x-esrehber");
            Types.Add("etx", "text/x-setext");
            Types.Add("evy", "application/envoy");
            Types.Add("exe", "application/octet-stream");
            Types.Add("f77", "text/plain");
            Types.Add("f90", "text/plain");
            Types.Add("fdf", "application/vnd.fdf");
            Types.Add("fif", "image/fif");
            Types.Add("fli", "video/fli");
            Types.Add("flo", "image/florian");
            Types.Add("flr", "x-world/x-vrml");
            Types.Add("flx", "text/vnd.fmi.flexstor");
            Types.Add("fmf", "video/x-atomic3d-feature");
            Types.Add("for", "text/plain");
            Types.Add("fpx", "image/vnd.fpx");
            Types.Add("frl", "application/freeloader");
            Types.Add("f", "text/plain");
            Types.Add("funk", "audio/make");
            Types.Add("g3", "image/g3fax");
            Types.Add("gif", "image/gif");
            Types.Add("gl", "video/gl");
            Types.Add("gsd", "audio/x-gsm");
            Types.Add("gsm", "audio/x-gsm");
            Types.Add("gsp", "application/x-gsp");
            Types.Add("gss", "application/x-gss");
            Types.Add("gtar", "application/x-gtar");
            Types.Add("g", "text/plain");
            Types.Add("gz", "application/x-gzip");
            Types.Add("gzip", "application/x-gzip");
            Types.Add("hdf", "application/x-hdf");
            Types.Add("help", "application/x-helpfile");
            Types.Add("hgl", "application/vnd.hp-HPGL");
            Types.Add("hh", "text/plain");
            Types.Add("hlb", "text/x-script");
            Types.Add("hlp", "application/x-helpfile");
            Types.Add("hpg", "application/vnd.hp-HPGL");
            Types.Add("hpgl", "application/vnd.hp-HPGL");
            Types.Add("hqx", "application/binhex");
            Types.Add("hta", "application/hta");
            Types.Add("htc", "text/x-component");
            Types.Add("h", "text/plain");
            Types.Add("htmls", "text/html");
            Types.Add("html", "text/html");
            Types.Add("htm", "text/html");
            Types.Add("htt", "text/webviewhtml");
            Types.Add("htx", "text/html");
            Types.Add("ice", "x-conference/x-cooltalk");
            Types.Add("ico", "image/x-icon");
            Types.Add("idc", "text/plain");
            Types.Add("ief", "image/ief");
            Types.Add("iefs", "image/ief");
            Types.Add("iges", "application/iges");
            Types.Add("igs", "application/iges");
            Types.Add("iii", "application/x-iphone");
            Types.Add("ima", "application/x-ima");
            Types.Add("imap", "application/x-httpd-imap");
            Types.Add("inf", "application/inf");
            Types.Add("ins", "application/x-internett-signup");
            Types.Add("ip", "application/x-ip2");
            Types.Add("isp", "application/x-internet-signup");
            Types.Add("isu", "video/x-isvideo");
            Types.Add("it", "audio/it");
            Types.Add("iv", "application/x-inventor");
            Types.Add("ivf", "video/x-ivf");
            Types.Add("ivr", "i-world/i-vrml");
            Types.Add("ivy", "application/x-livescreen");
            Types.Add("jam", "audio/x-jam");
            Types.Add("java", "text/plain");
            Types.Add("jav", "text/plain");
            Types.Add("jcm", "application/x-java-commerce");
            Types.Add("jfif", "image/jpeg");
            Types.Add("jfif-tbnl", "image/jpeg");
            Types.Add("jpeg", "image/jpeg");
            Types.Add("jpe", "image/jpeg");
            Types.Add("jpg", "image/jpeg");
            Types.Add("jps", "image/x-jps");
            Types.Add("js", "application/x-javascript");
            Types.Add("json", "application/application/json");
            Types.Add("jut", "image/jutvision");
            Types.Add("kar", "audio/midi");
            Types.Add("ksh", "text/x-script.ksh");
            Types.Add("la", "audio/nspaudio");
            Types.Add("lam", "audio/x-liveaudio");
            Types.Add("latex", "application/x-latex");
            Types.Add("list", "text/plain");
            Types.Add("lma", "audio/nspaudio");
            Types.Add("log", "text/plain");
            Types.Add("lsp", "application/x-lisp");
            Types.Add("lst", "text/plain");
            Types.Add("lsx", "text/x-la-asf");
            Types.Add("ltx", "application/x-latex");
            Types.Add("m13", "application/x-msmediaview");
            Types.Add("m14", "application/x-msmediaview");
            Types.Add("m1v", "video/mpeg");
            Types.Add("m2a", "audio/mpeg");
            Types.Add("m2v", "video/mpeg");
            Types.Add("m3u", "audio/x-mpequrl");
            Types.Add("m4u", "video/x-mpegurl");
            Types.Add("m4v", "video/mp4");
            Types.Add("m4a", "audio/mp4");
            Types.Add("m4r", "audio/mp4");
            Types.Add("m4b", "audio/mp4");
            Types.Add("m4p", "audio/mp4");
            Types.Add("man", "application/x-troff-man");
            Types.Add("manifest", "application/x-ms-manifest");
            Types.Add("map", "application/x-navimap");
            Types.Add("mar", "text/plain");
            Types.Add("mbd", "application/mbedlet");
            Types.Add("mc$", "application/x-magic-cap-package-1.0");
            Types.Add("mcd", "application/mcad");
            Types.Add("mcf", "image/vasa");
            Types.Add("mcp", "application/netmc");
            Types.Add("mdb", "application/x-msaccess");
            Types.Add("me", "application/x-troff-me");
            Types.Add("mht", "message/rfc822");
            Types.Add("mhtml", "message/rfc822");
            Types.Add("mid", "audio/midi");
            Types.Add("midi", "audio/midi");
            Types.Add("mif", "application/x-mif");
            Types.Add("mime", "message/rfc822");
            Types.Add("mjf", "audio/x-vnd.AudioExplosion.MjuiceMediaFile");
            Types.Add("mjpg", "video/x-motion-jpeg");
            Types.Add("mm", "application/base64");
            Types.Add("mme", "application/base64");
            Types.Add("mny", "application/x-msmoney");
            Types.Add("mod", "audio/mod");
            Types.Add("moov", "video/quicktime");
            Types.Add("movie", "video/x-sgi-movie");
            Types.Add("mov", "video/quicktime");
            Types.Add("mp2", "video/mpeg");
            Types.Add("mp3", "audio/mpeg3");
            Types.Add("mp4", "video/mp4");
            Types.Add("mp4v", "video/mp4");
            Types.Add("mpa", "audio/mpeg");
            Types.Add("mpc", "application/x-project");
            Types.Add("mpeg", "video/mpeg");
            Types.Add("mpe", "video/mpeg");
            Types.Add("mpga", "audio/mpeg");
            Types.Add("mpg", "video/mpeg");
            Types.Add("mpg4", "video/mp4");
            Types.Add("mpp", "application/vnd.ms-project");
            Types.Add("mpt", "application/x-project");
            Types.Add("mpv2", "video/mpeg");
            Types.Add("mpv", "application/x-project");
            Types.Add("mpx", "application/x-project");
            Types.Add("mrc", "application/marc");
            Types.Add("ms", "application/x-troff-ms");
            Types.Add("m", "text/plain");
            Types.Add("mvb", "application/x-msmediaview");
            Types.Add("mv", "video/x-sgi-movie");
            Types.Add("my", "audio/make");
            Types.Add("mzz", "application/x-vnd.AudioExplosion.mzz");
            Types.Add("nap", "image/naplps");
            Types.Add("naplps", "image/naplps");
            Types.Add("nc", "application/x-netcdf");
            Types.Add("ncm", "application/vnd.nokia.configuration-message");
            Types.Add("niff", "image/x-niff");
            Types.Add("nif", "image/x-niff");
            Types.Add("nix", "application/x-mix-transfer");
            Types.Add("nsc", "application/x-conference");
            Types.Add("nvd", "application/x-navidoc");
            Types.Add("nws", "message/rfc822");
            Types.Add("oda", "application/oda");
            Types.Add("ods", "application/oleobject");
            Types.Add("oga", "audio/ogg");
            Types.Add("ogg", "audio/ogg");
            Types.Add("ogv", "video/ogg");
            Types.Add("omc", "application/x-omc");
            Types.Add("omcd", "application/x-omcdatamaker");
            Types.Add("omcr", "application/x-omcregerator");
            Types.Add("otf", "application/x-font-otf");
            Types.Add("p10", "application/pkcs10");
            Types.Add("p12", "application/pkcs-12");
            Types.Add("p7a", "application/x-pkcs7-signature");
            Types.Add("p7b", "application/x-pkcs7-certificates");
            Types.Add("p7c", "application/pkcs7-mime");
            Types.Add("p7m", "application/pkcs7-mime");
            Types.Add("p7r", "application/x-pkcs7-certreqresp");
            Types.Add("p7s", "application/pkcs7-signature");
            Types.Add("part", "application/pro_eng");
            Types.Add("pas", "text/pascal");
            Types.Add("pbm", "image/x-portable-bitmap");
            Types.Add("pcl", "application/x-pcl");
            Types.Add("pct", "image/x-pict");
            Types.Add("pcx", "image/x-pcx");
            Types.Add("pdb", "chemical/x-pdb");
            Types.Add("pdf", "application/pdf");
            Types.Add("pfunk", "audio/make");
            Types.Add("pfx", "application/x-pkcs12");
            Types.Add("pgm", "image/x-portable-graymap");
            Types.Add("pic", "image/pict");
            Types.Add("pict", "image/pict");
            Types.Add("pkg", "application/x-newton-compatible-pkg");
            Types.Add("pko", "application/vnd.ms-pki.pko");
            Types.Add("pl", "text/plain");
            Types.Add("plx", "application/x-PiXCLscript");
            Types.Add("pm4", "application/x-pagemaker");
            Types.Add("pm5", "application/x-pagemaker");
            Types.Add("pma", "application/x-perfmon");
            Types.Add("pmc", "application/x-perfmon");
            Types.Add("pm", "image/x-xpixmap");
            Types.Add("pml", "application/x-perfmon");
            Types.Add("pmr", "application/x-perfmon");
            Types.Add("pmw", "application/x-perfmon");
            Types.Add("png", "image/png");
            Types.Add("pnm", "application/x-portable-anymap");
            Types.Add("pot", "application/mspowerpoint");
            Types.Add("pov", "model/x-pov");
            Types.Add("ppa", "application/vnd.ms-powerpoint");
            Types.Add("ppm", "image/x-portable-pixmap");
            Types.Add("pps", "application/mspowerpoint");
            Types.Add("ppt", "application/mspowerpoint");
            Types.Add("ppz", "application/mspowerpoint");
            Types.Add("pre", "application/x-freelance");
            Types.Add("prf", "application/pics-rules");
            Types.Add("prt", "application/pro_eng");
            Types.Add("ps", "application/postscript");
            Types.Add("p", "text/x-pascal");
            Types.Add("pub", "application/x-mspublisher");
            Types.Add("pvu", "paleovu/x-pv");
            Types.Add("pwz", "application/vnd.ms-powerpoint");
            Types.Add("pyc", "applicaiton/x-bytecode.python");
            Types.Add("py", "text/x-script.phyton");
            Types.Add("qcp", "audio/vnd.qcelp");
            Types.Add("qd3d", "x-world/x-3dmf");
            Types.Add("qd3", "x-world/x-3dmf");
            Types.Add("qif", "image/x-quicktime");
            Types.Add("qtc", "video/x-qtc");
            Types.Add("qtif", "image/x-quicktime");
            Types.Add("qti", "image/x-quicktime");
            Types.Add("qt", "video/quicktime");
            Types.Add("ra", "audio/x-pn-realaudio");
            Types.Add("ram", "audio/x-pn-realaudio");
            Types.Add("ras", "application/x-cmu-raster");
            Types.Add("rast", "image/cmu-raster");
            Types.Add("rexx", "text/x-script.rexx");
            Types.Add("rf", "image/vnd.rn-realflash");
            Types.Add("rgb", "image/x-rgb");
            Types.Add("rm", "application/vnd.rn-realmedia");
            Types.Add("rmi", "audio/mid");
            Types.Add("rmm", "audio/x-pn-realaudio");
            Types.Add("rmp", "audio/x-pn-realaudio");
            Types.Add("rng", "application/ringing-tones");
            Types.Add("rnx", "application/vnd.rn-realplayer");
            Types.Add("roff", "application/x-troff");
            Types.Add("rp", "image/vnd.rn-realpix");
            Types.Add("rpm", "audio/x-pn-realaudio-plugin");
            Types.Add("rss", "application/xml");
            Types.Add("rtf", "text/richtext");
            Types.Add("rt", "text/richtext");
            Types.Add("rtx", "text/richtext");
            Types.Add("rv", "video/vnd.rn-realvideo");
            Types.Add("s3m", "audio/s3m");
            Types.Add("sbk", "application/x-tbook");
            Types.Add("scd", "application/x-msschedule");
            Types.Add("scm", "application/x-lotusscreencam");
            Types.Add("sct", "text/scriptlet");
            Types.Add("sdml", "text/plain");
            Types.Add("sdp", "application/sdp");
            Types.Add("sdr", "application/sounder");
            Types.Add("sea", "application/sea");
            Types.Add("set", "application/set");
            Types.Add("setpay", "application/set-payment-initiation");
            Types.Add("setreg", "application/set-registration-initiation");
            Types.Add("sgml", "text/sgml");
            Types.Add("sgm", "text/sgml");
            Types.Add("shar", "application/x-bsh");
            Types.Add("sh", "text/x-script.sh");
            Types.Add("shtml", "text/html");
            Types.Add("sid", "audio/x-psid");
            Types.Add("sit", "application/x-sit");
            Types.Add("skd", "application/x-koan");
            Types.Add("skm", "application/x-koan");
            Types.Add("skp", "application/x-koan");
            Types.Add("skt", "application/x-koan");
            Types.Add("sl", "application/x-seelogo");
            Types.Add("smi", "application/smil");
            Types.Add("smil", "application/smil");
            Types.Add("snd", "audio/basic");
            Types.Add("sol", "application/solids");
            Types.Add("spc", "application/x-pkcs7-certificates");
            Types.Add("spl", "application/futuresplash");
            Types.Add("spr", "application/x-sprite");
            Types.Add("sprite", "application/x-sprite");
            Types.Add("spx", "audio/ogg");
            Types.Add("src", "application/x-wais-source");
            Types.Add("ssi", "text/x-server-parsed-html");
            Types.Add("ssm", "application/streamingmedia");
            Types.Add("sst", "application/vnd.ms-pki.certstore");
            Types.Add("step", "application/step");
            Types.Add("s", "text/x-asm");
            Types.Add("stl", "application/sla");
            Types.Add("stm", "text/html");
            Types.Add("stp", "application/step");
            Types.Add("sv4cpio", "application/x-sv4cpio");
            Types.Add("sv4crc", "application/x-sv4crc");
            Types.Add("svf", "image/x-dwg");
            Types.Add("svg", "image/svg+xml");
            Types.Add("svgz", "image/svg+xml");
            Types.Add("svr", "application/x-world");
            Types.Add("swf", "application/x-shockwave-flash");
            Types.Add("talk", "text/x-speech");
            Types.Add("t", "application/x-troff");
            Types.Add("tar", "application/x-tar");
            Types.Add("tbk", "application/toolbook");
            Types.Add("tcl", "text/x-script.tcl");
            Types.Add("tcsh", "text/x-script.tcsh");
            Types.Add("tex", "application/x-tex");
            Types.Add("texi", "application/x-texinfo");
            Types.Add("texinfo", "application/x-texinfo");
            Types.Add("text", "text/plain");
            Types.Add("tgz", "application/x-compressed");
            Types.Add("tiff", "image/tiff");
            Types.Add("tif", "image/tiff");
            Types.Add("torrent", "application/x-bittorrent");
            Types.Add("tr", "application/x-troff");
            Types.Add("trm", "application/x-msterminal");
            Types.Add("tsi", "audio/tsp-audio");
            Types.Add("tsp", "audio/tsplayer");
            Types.Add("tsv", "text/tab-separated-values");
            Types.Add("ttf", "application/x-font-ttf");
            Types.Add("turbot", "image/florian");
            Types.Add("txt", "text/plain");
            Types.Add("uil", "text/x-uil");
            Types.Add("uls", "text/iuls");
            Types.Add("unis", "text/uri-list");
            Types.Add("uni", "text/uri-list");
            Types.Add("unv", "application/i-deas");
            Types.Add("uris", "text/uri-list");
            Types.Add("uri", "text/uri-list");
            Types.Add("ustar", "multipart/x-ustar");
            Types.Add("uue", "text/x-uuencode");
            Types.Add("uu", "text/x-uuencode");
            Types.Add("vcd", "application/x-cdlink");
            Types.Add("vcf", "text/x-vcard");
            Types.Add("vcs", "text/x-vCalendar");
            Types.Add("vda", "application/vda");
            Types.Add("vdo", "video/vdo");
            Types.Add("vew", "application/groupwise");
            Types.Add("vivo", "video/vivo");
            Types.Add("viv", "video/vivo");
            Types.Add("vmd", "application/vocaltec-media-desc");
            Types.Add("vmf", "application/vocaltec-media-file");
            Types.Add("voc", "audio/voc");
            Types.Add("vos", "video/vosaic");
            Types.Add("vox", "audio/voxware");
            Types.Add("vqe", "audio/x-twinvq-plugin");
            Types.Add("vqf", "audio/x-twinvq");
            Types.Add("vql", "audio/x-twinvq-plugin");
            Types.Add("vrml", "application/x-vrml");
            Types.Add("vrt", "x-world/x-vrt");
            Types.Add("vsd", "application/x-visio");
            Types.Add("vst", "application/x-visio");
            Types.Add("vsw", "application/x-visio");
            Types.Add("w60", "application/wordperfect6.0");
            Types.Add("w61", "application/wordperfect6.1");
            Types.Add("w6w", "application/msword");
            Types.Add("wav", "audio/wav");
            Types.Add("wb1", "application/x-qpro");
            Types.Add("wbmp", "image/vnd.wap.wbmp");
            Types.Add("wcm", "application/vnd.ms-works");
            Types.Add("wdb", "application/vnd.ms-works");
            Types.Add("web", "application/vnd.xara");
            Types.Add("webm", "video/webm");
            Types.Add("wiz", "application/msword");
            Types.Add("wk1", "application/x-123");
            Types.Add("wks", "application/vnd.ms-works");
            Types.Add("wmf", "windows/metafile");
            Types.Add("wmlc", "application/vnd.wap.wmlc");
            Types.Add("wmlsc", "application/vnd.wap.wmlscriptc");
            Types.Add("wmls", "text/vnd.wap.wmlscript");
            Types.Add("wml", "text/vnd.wap.wml");
            Types.Add("woff", "application/x-woff");
            Types.Add("word", "application/msword");
            Types.Add("wp5", "application/wordperfect");
            Types.Add("wp6", "application/wordperfect");
            Types.Add("wp", "application/wordperfect");
            Types.Add("wpd", "application/wordperfect");
            Types.Add("wps", "application/vnd.ms-works");
            Types.Add("wq1", "application/x-lotus");
            Types.Add("wri", "application/mswrite");
            Types.Add("wrl", "application/x-world");
            Types.Add("wrz", "model/vrml");
            Types.Add("wsc", "text/scriplet");
            Types.Add("wsdl", "application/xml");
            Types.Add("wsrc", "application/x-wais-source");
            Types.Add("wtk", "application/x-wintalk");
            Types.Add("xaf", "x-world/x-vrml");
            Types.Add("xaml", "application/xaml+xml");
            Types.Add("xap", "application/x-silverlight-app");
            Types.Add("xbap", "application/x-ms-xbap");
            Types.Add("xbm", "image/x-xbitmap");
            Types.Add("xdr", "video/x-amt-demorun");
            Types.Add("xgz", "xgl/drawing");
            Types.Add("xhtml", "application/xhtml+xml");
            Types.Add("xht", "application/xhtml+xml");
            Types.Add("xif", "image/vnd.xiff");
            Types.Add("xla", "application/excel");
            Types.Add("xl", "application/excel");
            Types.Add("xlb", "application/excel");
            Types.Add("xlc", "application/excel");
            Types.Add("xld", "application/excel");
            Types.Add("xlk", "application/excel");
            Types.Add("xll", "application/excel");
            Types.Add("xlm", "application/excel");
            Types.Add("xls", "application/excel");
            Types.Add("xlt", "application/excel");
            Types.Add("xlv", "application/excel");
            Types.Add("xlw", "application/excel");
            Types.Add("csv", "text/csv");
            Types.Add("xm", "audio/xm");
            Types.Add("xml", "application/xml");
            Types.Add("xmz", "xgl/movie");
            Types.Add("xof", "x-world/x-vrml");
            Types.Add("xpi", "application/x-xpinstall");
            Types.Add("xpix", "application/x-vnd.ls-xpix");
            Types.Add("xpm", "image/xpm");
            Types.Add("x-png", "image/png");
            Types.Add("xsd", "application/xml");
            Types.Add("xsl", "application/xml");
            Types.Add("xsr", "video/x-amt-showrun");
            Types.Add("xwd", "image/x-xwd");
            Types.Add("xyz", "chemical/x-pdb");
            Types.Add("z", "application/x-compressed");
            Types.Add("zip", "application/zip");
            Types.Add("zsh", "text/x-script.zsh");

            // Office Formats
            Types.Add("docm", "application/vnd.ms-word.document.macroEnabled.12");
            Types.Add("docx", "application/vnd.openxmlformats-officedocument.wordprocessingml.document");
            Types.Add("dotm", "application/vnd.ms-word.template.macroEnabled.12");
            Types.Add("dotx", "application/vnd.openxmlformats-officedocument.wordprocessingml.template");
            Types.Add("potm", "application/vnd.ms-powerpoint.template.macroEnabled.12");
            Types.Add("potx", "application/vnd.openxmlformats-officedocument.presentationml.template");
            Types.Add("ppam", "application/vnd.ms-powerpoint.addin.macroEnabled.12");
            Types.Add("ppsm", "application/vnd.ms-powerpoint.slideshow.macroEnabled.12");
            Types.Add("ppsx", "application/vnd.openxmlformats-officedocument.presentationml.slideshow");
            Types.Add("pptm", "application/vnd.ms-powerpoint.presentation.macroEnabled.12");
            Types.Add("pptx", "application/vnd.openxmlformats-officedocument.presentationml.presentation");
            Types.Add("xlam", "application/vnd.ms-excel.addin.macroEnabled.12");
            Types.Add("xlsb", "application/vnd.ms-excel.sheet.binary.macroEnabled.12");
            Types.Add("xlsm", "application/vnd.ms-excel.sheet.macroEnabled.12");
            Types.Add("xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
            Types.Add("xltm", "application/vnd.ms-excel.template.macroEnabled.12");
            Types.Add("xltx", "application/vnd.openxmlformats-officedocument.spreadsheetml.template");
        }

        public static string GetMimeType(string fileName)
        {
            if (fileName == null) { return null; }
            string result = null;
            var dot = fileName.LastIndexOf('.');
            if (dot != -1 && fileName.Length > dot + 1) { Types.TryGetValue(fileName.Substring(dot + 1), out result); }
            return result ?? "application/octet-stream";
        }
    }
}