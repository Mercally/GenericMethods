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