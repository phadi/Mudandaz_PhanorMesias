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

function saveTextAsFile() {
  // grab the content of the form field and place it into a variable
  var textToWrite = document.getElementById("contenidoOutput").value;
  if (textToWrite != "") {
    var textFileAsBlob = new Blob([textToWrite], { type: 'text/plain' });
    var fileNameToSaveAs = "outputText.txt";

    var downloadLink = document.createElement("a");
    
    downloadLink.download = fileNameToSaveAs;
    
    downloadLink.innerHTML = "My Hidden Link";

    window.URL = window.URL || window.webkitURL;

    downloadLink.href = window.URL.createObjectURL(textFileAsBlob);
    
    downloadLink.onclick = destroyClickedElement;
    
    downloadLink.style.display = "none";
    
    document.body.appendChild(downloadLink);

    downloadLink.click();
  }
  
}

function destroyClickedElement(event) {
  document.body.removeChild(event.target);
}
