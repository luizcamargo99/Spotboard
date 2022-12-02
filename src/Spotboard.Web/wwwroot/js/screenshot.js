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
    html2canvas(element).then(function (canvas) {
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
        party.confetti(document.getElementById('save-btn'), {
            count: party.variation.range(20, 40),
        });
   
    } else {
        window.open(uri);
    }
}