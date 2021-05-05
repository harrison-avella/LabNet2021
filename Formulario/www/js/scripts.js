$(document).ready(function () {  
    function validarCampos() {
        var valido = true;
        var nombre = $('#nombre').val();
        if (nombre.length == 0) {
            valido = false;
        };
        var apellido = $('#apellido').val();
        if (apellido.length == 0) {
            valido = false;
        };
        var empresa = $('#empresa').val();
        if (empresa.length == 0) {
            valido = false;
        };
        return valido;
    }


    $('#enviar').click(function () {
        if (validarCampos()) {
            alert("Solicitud realizada con exito");
        } else{
            alert("Por favor llena los datos")
        };
    });

})
