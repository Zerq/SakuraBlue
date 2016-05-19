class RayCaster {
    constructor() {
        this.bitmap = document.getElementById("resource");
        this.canvas = document.getElementById("screen");
        this.ctx = this.canvas.getContext("2d");
        this.ctx['imageSmoothingEnabled'] = false; /* standard */
        this.ctx['mozImageSmoothingEnabled'] = false; /* Firefox */
        this.ctx['oImageSmoothingEnabled'] = false; /* Opera */
        this.ctx['webkitImageSmoothingEnabled'] = false; /* Safari */
        this.ctx['msImageSmoothingEnabled'] = false; /* IE */
    }
}
class player {
}
