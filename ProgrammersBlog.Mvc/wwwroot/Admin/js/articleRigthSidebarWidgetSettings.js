$(document).ready(function() {

    $('#categoryList').select2({
        theme: "bootstrap4",
        allowClear: true,
        placeholder:"Kategori Seçiniz"
    });
    $('#filterByList').select2({
        theme: "bootstrap4",
        allowClear: true,
        placeholder: "Lütfen Bir Filtre Türü Seçiniz"
    });
    $('#orderByList').select2({
        theme: "bootstrap4",
        allowClear: true,
        placeholder: "Lütfen Bir Sıralama Türü Seçiniz"
    });
    $('#isAscendingList').select2({
        theme: "bootstrap4",
        allowClear: true,
        placeholder: "Lütfen Bir Sıralama Tipi Seçiniz"
    });
    $("#startAtDatePicker").datepicker({
        closeText: "kapat",
        prevText: "&#x3C;geri",
        nextText: "ileri&#x3e",
        currentText: "bugün",
        monthNames: ["Ocak", "Şubat", "Mart", "Nisan", "Mayıs", "Haziran",
            "Temmuz", "Ağustos", "Eylül", "Ekim", "Kasım", "Aralık"],
        monthNamesShort: ["Oca", "Şub", "Mar", "Nis", "May", "Haz",
            "Tem", "Ağu", "Eyl", "Eki", "Kas", "Ara"],
        dayNames: ["Pazar", "Pazartesi", "Salı", "Çarşamba", "Perşembe", "Cuma", "Cumartesi"],
        dayNamesShort: ["Pz", "Pt", "Sa", "Ça", "Pe", "Cu", "Ct"],
        dayNamesMin: ["Pz", "Pt", "Sa", "Ça", "Pe", "Cu", "Ct"],
        weekHeader: "Hf",
        dateFormat: "dd.mm.yy",
        firstDay: 1,
        duration:1000,
        showAnim: "drop",
        showOptions: {direction : "down"},
        isRTL: false,
        showMonthAfterYear: false,
        yearSuffix: "",
        maxDate:0
    });

    $("#endAtDatePicker").datepicker({
        closeText: "kapat",
        prevText: "&#x3C;geri",
        nextText: "ileri&#x3e",
        currentText: "bugün",
        monthNames: ["Ocak", "Şubat", "Mart", "Nisan", "Mayıs", "Haziran",
            "Temmuz", "Ağustos", "Eylül", "Ekim", "Kasım", "Aralık"],
        monthNamesShort: ["Oca", "Şub", "Mar", "Nis", "May", "Haz",
            "Tem", "Ağu", "Eyl", "Eki", "Kas", "Ara"],
        dayNames: ["Pazar", "Pazartesi", "Salı", "Çarşamba", "Perşembe", "Cuma", "Cumartesi"],
        dayNamesShort: ["Pz", "Pt", "Sa", "Ça", "Pe", "Cu", "Ct"],
        dayNamesMin: ["Pz", "Pt", "Sa", "Ça", "Pe", "Cu", "Ct"],
        weekHeader: "Hf",
        dateFormat: "dd.mm.yy",
        firstDay: 1,
        duration: 1000,
        showAnim: "drop",
        showOptions: { direction: "down" },
        isRTL: false,
        showMonthAfterYear: false,
        yearSuffix: ""
    });
});