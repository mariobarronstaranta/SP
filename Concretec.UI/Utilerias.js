function OnEnterGoClick(idClickControl) {
    if (event.keyCode == 13) {

        var control;
        if (document.getElementById) {
            control = document.getElementById(idClickControl);
        }
        else {
            control = $get(idClickControl);
        }
        control.click();
    }
}

function ValidarComentario(obj) {
    var control = document.getElementById(obj);
    if (control.value != " " && control.value != "") {
        var iChars = "!$^&*[]\\\'{}|\":<>?";
        for (var i = 0; i < control.value.length; i++) {
            if (iChars.indexOf(control.value.charAt(i)) != -1) {
                alert('Caracteres Invalidos');
                return false;
            }
        }
        var answer = confirm("Desea realizar el cambio?")
        if (!answer) {
            return false;
        }

    } else {
        alert("Campo 'Comentario' es Obligatorio");
        return false;
    }
}

function ValidarBusqueda() {

    alert("50 caracteres maximo");
    return false;

}

function Openpopup(popurl) {
    winpops = window.open(popurl, "", "width=340, height=300, left=45, top=15, scrollbars=yes, menubar=no,resizable=no,directories=no,location=no")
}

function OpenChild(idContrato) {
    var WinSettings = "center:yes;resizable:no;dialogHeight:300px"
    var MyArgs = window.showModalDialog("ViewComments.aspx?cntrt=" + idContrato, MyArgs, WinSettings);
}

   