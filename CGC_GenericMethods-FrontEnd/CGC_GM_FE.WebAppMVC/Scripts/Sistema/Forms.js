"use strict";

window.addEventListener("submit", function (e) {
    e.preventDefault();
    e.stopPropagation();
    e.stopImmediatePropagation();
    
    //if (validarInputs() === false) { return; }

    if (this.confirm("Guardar?")) {
        enviarForm(e);
    }
}, true);

function enviarForm(e) {
    var form = e.target;

    if (form.dataset.ajax) {
        var xhr = new XMLHttpRequest();
        xhr.open(form.method, form.action, true);
        xhr.onreadystatechange = function () {
            if (xhr.readyState === 4 && xhr.status === 200) {
                var data = JSON.parse(xhr.response);
                if (data) {
                    alert(data["Message"]);
                } else {
                    alert("Error");
                }
            } else {
                if (xhr.readyState === 4 && xhr.status !== 200) {
                    // Error
                    alert("Error");
                }
            }
        };

        var formData = new FormData(form);

        xhr.send(formData);
    }
}

function openModal(action, method, divmodal) {
    ajaxHelper(action, method, function (html) {
        var div = document.getElementById(divmodal);
        var divBody = div.querySelector(".modal-body");
        divBody.innerHTML = html;
    }, true, "html");
}

$(document).on("click", "button.btn-save-modal", function (e) {
    if (document.getElementsByClassName("modal-body").length > 0) {
        document.getElementsByClassName("modal-body")[0].querySelector("input[type=submit]").click();
    }
});

function ajaxHelper(action, method, onSuccessCallback, async, dataType) {
    if (async === undefined) {
        async = true;
    }

    var xhr = new XMLHttpRequest();
    xhr.open(method, action, async);
    xhr.onreadystatechange = function () {
        if (xhr.readyState === 4 && xhr.status === 200) {
            var data = {};
            switch (dataType) {
                case "html":
                    data = xhr.responseText;
                    break;
                default:
                    data = JSON.parse(xhr.response);
                    break;
            }
            onSuccessCallback(data);
        } else {
            if (xhr.readyState === 4 && xhr.status !== 200) {
                alert("Error");
            }
        }
    };

    xhr.send();
}

$(function () {
    $('[data-toggle="tooltip"]').tooltip(
        {
            delay: { "show": 700, "hide": 100 }
        }
    );
});