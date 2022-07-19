var Validations = {
    Date: /^(\d{4})[\\\/\-](\d{1,2})[\\\/\-](\d{1,2})$/,
    DateTime: /^(\d{4})[\\\/\-](\d{1,2})[\\\/\-](\d{1,2})\s(\d{1,2}):(\d{1,2}):(\d{1,2})$/,
    Time: /^(\d{1,2}):(\d{1,2}):(\d{1,2})$/,
    Email: /^\w+([\-+.']\w+)*@\w+([\-.]\w+)*\.\w+([\-.]\w+)*$/,
    Url: /^http(s)?:\/\/([\w\-]+\.)+[\w\-]+(\/[\w\- .\/?%&amp;=]*)?$/,
    LatinCharAndNum: /^[\sa-zA-Z0-9.]*$/,
    Number: /^(?:-?(?:\d+|\d{1,3}(?:,\d{3})+)(?:\.\d+)?)$/,
    Digit: /^[\d,٠١٢٣٤٥٦٧٨٩۰۱۲۳۴۵۶۷۸۹]*$/,
    LatinChar: /^[\sa-zA-Z]*$/,
    FarsiChar: /^[\sءآأؤئةكيگوکذىىلآدءٍفإجژچپشذزیثبلاهتنمئدخحضقسفعرصطغظ]*$/,
    FarsiCharAndNum: /^[٠١٢٣٤٥٦٧٨٩۰۱۲۳۴۵۶۷۸۹كيا-یء-ی 0-9]+$/,
    PostCode: /^\d{10}$/,
    Mobile: /^09[0-9]{9}$/,
    Username: /^[a-z0-9]*$/,
    Address: /^[\-كيا-یء-ی 0-9-,\/.()a-zA-Z،]+$/,
    Tel: /^\d{8}$/,
    TelWithCode: /^0\d{10}$/,
    WebSite: /^www([.]([a-z0-9]{1,})(([-]*)([a-z0-9]{1,}))*){1,}[.]([a-z]{1,})$/i,
    PassportCode: /^[a-zA-Z0-9]*$/,
    ResidenceCode: /^[0-9]{8}$|^[0-9]{13}$/,
    ForeignerPervasiveNo: /^\d{10,16}$/,
    IsNationalCode: function (code) {
        var isNumbers = /^\d{10}$/.test(code);
        if (!isNumbers) return false;
        var isAllSame = true;
        var i;
        for (i = 1; i < 10; i++) {
            isAllSame = (code.charAt(0) == code.charAt(i));
            if (!isAllSame) break;
        }
        if (isAllSame) return false;
        var l = code.length;
        if (l < 8 || parseInt(code, 10) == 0) return false;
        code = ('0000' + code)
            .substr(l + 4 - 10);
        if (parseInt(code.substr(3, 6), 10) == 0) return false;
        var c = parseInt(code.substr(9, 1), 10);
        var s = 0;
        for (i = 0; i < 9; i++) s += parseInt(code.substr(i, 1), 10) * (10 - i);
        s = s % 11;
        return (s < 2 && c == s) || (s >= 2 && c == (11 - s));
    }
};