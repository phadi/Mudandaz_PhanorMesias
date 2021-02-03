$(document).ready(function () {

  $(document).on('change', 'input[type=file]', function (e) {
    leerArchivo(e);
  });

});

function leerArchivo(e) {
  var archivo = e.target.files[0];
  if (!archivo) {
    return;
  }
  var lector = new FileReader();
  lector.onload = function (e) {
    var contenido = e.target.result;
    mostrarContenido(contenido);
  };
  lector.readAsText(archivo);
}

function mostrarContenido(contenido) {
  var elemento = document.getElementById('contenidoInput');
  elemento.innerHTML = contenido;
}
