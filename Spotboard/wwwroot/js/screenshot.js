function createImageByElement(id, canvasDestination) {
    html2canvas(document.getElementById(id)).then(canvas => {
        let canvasID = document.getElementById(canvasDestination);
        let ctx = canvasID.getContext('2d');
        ctx.scale(1, 1);
        ctx.width = window.innerWidth / 3;
        ctx.height = window.innerHeight / 3;
        ctx.drawImage(canvas, 0, 0);
    });
}

function downloadScreenshot(id, filename) {
    let element = document.getElementById(id);
    /* element.style.scale = 1;*/
/*    let clone = hiddenClone(element);*/
    html2canvas(element, {
        scrollX: 0,
        scrollY: 0
    }).then(function (canvas) {
  /*      document.body.removeChild(clone);*/
        saveAs(canvas.toDataURL(), filename + '.png')
    });
}

function saveAs(uri, filename) {
    var link = document.createElement('a');
    if (typeof link.download === 'string') {
        link.href = uri;
        link.download = filename;
        document.body.appendChild(link);
        link.click();
        document.body.removeChild(link);
    } else {
        window.open(uri);
    }
}

function hiddenClone(element) {
    // Create clone of element
    var clone = element.cloneNode(true);

    // Position element relatively within the
    // body but still out of the viewport
    var style = clone.style;
    //style.position = 'relative';
    //style.top = window.innerHeight + 'px';
    style.visibility = "none";
    //style.left = 0;

    style.scale = 1.2;
    // Append clone to body and return the clone
    document.body.appendChild(clone);
    return clone;
}