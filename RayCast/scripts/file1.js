class Game {
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
    DrawMiniMap() {
        this.ctx.drawImage(this.bitmap, 129, 0, 37, 45, 0, 0, 37 * 4, 45 * 4);
    }
}
var game;
window.addEventListener("load", function () {
    game = new Game();
    game.DrawMiniMap();
});
