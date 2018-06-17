function Declare(namespaceString, objectLiteral) {
    if (!namespaceString) {
        throw "namespaceString must be set";
    }
    var namespaceObj = window;
    var namespaceNames = namespaceString.split(".");
    for (var i = 0; i < namespaceNames.length; i++) {
        var name = namespaceNames[i];
        namespaceObj[name] = namespaceObj[name] || {};
        if (i === namespaceNames.length - 1) {
            namespaceObj[name] = $.extend(namespaceObj[name], objectLiteral);
        }
        namespaceObj = namespaceObj[name];
    }
    return objectLiteral;
}

$(document.body).on("keydown", ".decimal", function (e) {
    handleDecimal(e);
});

$(document.body).on("blue", ".decimal", function (e) {
    accounting.formatNumer(e, 2);
});

function handleDecimal(e) {
    // Allow: backspace, delete, tab, escape, enter and .
    if ($.inArray(e.keyCode, [46, 8, 9, 27, 13, 110, 190]) !== -1 ||
        (e.keyCode == 65 && e.ctrlKey === true) ||
        (e.keyCode >= 35 && e.keyCode <= 39)) {
        return;
    }
    // Ensure that it is a number and stop the keypress
    if ((e.shiftKey || (e.keyCode < 48 || e.keyCode > 57)) && (e.keyCode < 96 || e.keyCode > 105)) {
        e.preventDefault();
    }
}

function toJavaScriptDate(value) {
    var pattern = /Date\(([^)]+)\)/;
    var results = pattern.exec(value);
    var dt = new Date(parseFloat(results[1]));
    return (dt.getMonth() + 1) + "/" + dt.getDate() + "/" + dt.getFullYear();
}

function toLogTime(value) {
    var hours = value.Hours;
    var minutes = value.Minutes;

    if (hours < 10)
        hours = "0" + hours;

    if (minutes < 10)
        minutes = "0" + minutes;

    return hours + ":" + minutes;
}
/// assumes the time strings are coming from the app, so we can skip the checks
function addLogTime(timeString1, timeString2) {
    var split1 = timeString1.split(":");
    var split2 = timeString2.split(":");

    var hour1 = split1[0];
    var hour2 = split2[0];

    var minutes1 = split1[1];
    var minutes2 = split2[1];

    var totalMinutes = (parseInt(hour1) * 60) + (parseInt(hour2) * 60) + parseInt(minutes1) + parseInt(minutes2);

    var totalHours = Math.floor(totalMinutes / 60);
    var minutes = totalMinutes - (totalHours * 60);

    if (totalHours < 10) {
        totalHours = "0" + totalHours;
    }

    if (minutes < 10) {
        minutes = "0" + minutes;
    }
    return totalHours + ":" + minutes + ":" + "00";
}


$(function () {
    if ($.blockUI) {
        $.blockUI.defaults.css.cursor = 'default';

        $.blockUI.defaults.message = '<h4>Please wait...</h4><p><i class="fa fa-circle-o-notch fa-pulse fa-2x fa-spin" style="font-size: 40px;"></i></p>';
        var style = {
            'box-shadow': '0 5px 15px rgba(0, 0, 0, 0.5)',
            'border': '1px solid rgba(0, 0, 0, 0.2)',
            'border-radius': "6px",
            'background-color': '#0275d8',
            'color': 'white',
            'outline': '0',
            'padding': '15px'
        };
        $.blockUI.defaults.css = $.extend($.blockUI.defaults.css, style);
    }
})