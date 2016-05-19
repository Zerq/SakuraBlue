
class Grid {
    private ary: number[][];
    public Get(x: number, y: number): number {
        if (this.ary[x] !== undefined) {
            if (this.ary[x][y] !== undefined) {
                return this.ary[x][y];
            } else {
                return null;
            }
        } else {
            return null;
        }
    }
    public Set(x: number, y: number, val: number): void {
     
                this.ary[x][y] = val;
     
    }
 
    private xMax: number;
    private yMax: number;
    public constructor(xMax: number, yMax: number) {
        this.xMax = xMax;
        this.yMax = yMax;
        this.ary = [];
        for (var x = 0; x < xMax; x++) {
            this.ary[x] = [];
            for (var y = 0; y < yMax; y++) {
        
               
                this.ary[x][y] = 0;
            }
        }     
    }

    public Traverse(func: (nr: number, x: number, y: number) => void): void {
        for (var y = 0; y < this.yMax; y++) {
            for (var x = 0; x < this.xMax; x++) {
                func(this.ary[x][y], x, y);
            }
        }
    } 

}
enum TileType {
    Player,
    NonRender,
    Normal,
    Sprite
}
class Tile {
    public constructor(id: number, color: string, x: number, y: number, type: TileType) {
        this.id = id;
        this.color = color;
        this.x = x;
        this.y = y;
        this.type = type;
    
    }
    private id: number;
    private color: string;
    private x: number;
    private y: number;
    private type: TileType;
    public get Id(): number {
        return this.id;
    }
    public get Color(): string {
        return this.color;
    }
    public get X(): number {
        return this.x;
    }
    public get Y(): number {
        return this.y;
    }
    public get Type(): TileType {
        return this.type;
    }

}

function thingy(): number { return (Math.PI * 2) / 360; }

class RayCastResult {
    private pixelColumn: number;
    public get PixelColumn(): number {
        return this.pixelColumn;
    }
    
    private tile: Tile;
    public get Tile(): Tile {
        return this.tile;
    }

    private rayLenght: number;
    public get RayLenght(): number {
        return this.rayLenght;
    }

    //temp to test shit--->
    public x: number;
    public y: number;
    //temp to test shit<---
    public constructor(pixelColumn: number, tile: Tile, rayLenght: number) {
        this.pixelColumn = pixelColumn;
        this.tile = tile;
        this.rayLenght = rayLenght;
    }
}
function RayCast(angle: number, posX: number, posY: number, step: number, MaxStep: number, map: Grid, tileset: Array<Tile>, tileWidth: number, tileHeight: number): any {
    var newAngle = thingy() * ((angle + 180) % 360); 
    var sin = Math.sin(newAngle);
    var cos = Math.cos(newAngle);
    var newX = Math.round((posX + cos) * 100) / 100;
    var newY = Math.round((posY + sin) * 100) / 100;
    var tile = tileset[map.Get(Math.round(newX), Math.round(newY))];
    if (tile === null || tile === undefined) {
        return null;
    }
    if (tile.Type == TileType.Normal) {  
        return tileset[map.Get(Math.round(newX), Math.round(newY))];
// return the tile if this hits something so we know what hitts
//this will not be the final result which should be a raycastResult....
    } else {
    //ok this was just an empty cell move onwards!
        var result = RayCast(angle, newX, newY, step + 1, MaxStep, map, tileset, tileWidth, tileHeight);
        
        if (result instanceof RayCastResult) {
            return result; // yay we got our final result! Perfect!
        }
  
        if (result instanceof Tile) {

            if (!result) {
                return null;
            }

            var x = newX % 1; //I just want the face on the hypotetical square so i can determin directionality of he texture...
            var y = newY % 1;      

            if (x === 0 && y === 0) {
                //WTF?!
                var i = 0;
            }
            else {
                if (x === 0) {
                    var temp = new RayCastResult(Math.round(y * tileHeight), result, step);
                    temp.x = newX;
                    temp.y = newY;
                    return temp;
                }

                if (y === 0) {
                   var temp = new RayCastResult(Math.round(x * tileHeight), result, step);
                   temp.x = newX;
                   temp.y = newY;
                   return temp;
                }
            }

               
        }
        if (step + 1 === MaxStep) {
            return null; //FUCK IT I GIVE UP! this ray timed out!
            //this is to cover the case of an map without walls where you can just stair out into infinity...
        }
    }    
}

class Game {
    private tileset: Array<Tile>;
    private Player:Player
    private width: number;
    private height: number;
    public get Width(): number {
        return this.width;
    }
    public get Height(): number {
        return this.height;
    }

    private tileWidth: number;
    private tileHeight: number;


    private xPos: number;
    private yPos: number;
    public get XPos(): number {
        return this.xPos;
    }
    public get YPos(): number {
        return this.yPos;
    }

    private toHex(nr: number): string {   
        var str = nr.toString(16)
        var pad = "00"
       return pad.substring(0, pad.length - str.length) + str
   
    }
    private GetColor(x: number, y: number, ctx: CanvasRenderingContext2D): string {
        var data = ctx.getImageData(x, y, 1, 1).data;
        return "#" + this.toHex(data[0]) + this.toHex(data[1]) + this.toHex(data[2]);       
    }

    private bitmap: HTMLImageElement; 
    private ctx: CanvasRenderingContext2D;
    private ctxMap: CanvasRenderingContext2D;
    private ctxfake3d: CanvasRenderingContext2D;

    private map: Grid;
    private GetContext(id: string): CanvasRenderingContext2D {
        var canvas = document.getElementById(id) as HTMLCanvasElement;
        var ctx = canvas.getContext("2d") as CanvasRenderingContext2D;
        ctx['imageSmoothingEnabled'] = false;       /* standard */
        ctx['mozImageSmoothingEnabled'] = false;    /* Firefox */
        ctx['oImageSmoothingEnabled'] = false;      /* Opera */
        ctx['webkitImageSmoothingEnabled'] = false; /* Safari */
        ctx['msImageSmoothingEnabled'] = false;     /* IE */
        return ctx;
    }    

    public constructor(xPos: number, yPos: number, width: number, height: number, tileset: Tile[], tileWidth, tileHeight) {
        this.tileWidth = tileWidth;
        this.tileHeight = tileHeight;
        this.yPos = yPos;
        this.xPos = xPos;
        this.height = height;
        this.width = width;
        this.map = new Grid(width, height);
        this.tileset = tileset;


        this.bitmap = document.getElementById("resource") as HTMLImageElement;
        this.Player = new Player(120, this);
        this.Player.RigEvents();
        this.ctx = this.GetContext("screen");
        this.ctxMap = this.GetContext("map");
        this.ctxfake3d = this.GetContext("3d");
        this.ctxMap.drawImage(this.bitmap, this.XPos, this.YPos, this.Width, this.Height, 0, 0, this.Width, this.Height);
        var data = this.GetColor(0, 0, this.ctxMap);

        for (var y = 0; y < width; y++) {
            for (var x = 0; x < width; x++) {
                var color = this.GetColor(x, y, this.ctxMap);


                var tile = this.tileset.find(n => n.Color == color);
                switch (tile.Type) {
                    case TileType.Normal:
                        this.map.Set(x, y, tile.Id);
                        break;
                    case TileType.Player:
                        this.Player.X = x * this.tileWidth;
                        this.Player.Y = y * this.tileHeight;
                        this.map.Set(x, y, this.tileset[0].Id);
                        break;
                    case TileType.NonRender:
                        this.map.Set(x, y, this.tileset[0].Id);
                        break;
                    case TileType.Sprite:
                        //todo...
                        this.map.Set(x, y, this.tileset[0].Id);
                        break;

                }

           

                if (color === "#ffffff") {
               
                } else {
             
                }
            }
        }

  
    }

    public DrawMap(): void {
                this.ctx.clearRect(0, 0, this.Width * this.tileHeight, this.Height * this.tileHeight);
        this.map.Traverse((tileRef, x, y) => {

            var tile: Tile = this.tileset.find(m => m.Id === tileRef);  
            if (tile.Type === TileType.Normal) {
                this.ctx.drawImage(this.bitmap, tile.X, tile.Y, this.tileWidth, this.tileHeight, x * this.tileWidth, y * this.tileHeight, this.tileWidth, this.tileHeight);
            }

        });





        var sin = Math.sin(thingy() * -((this.Player.Rotation + 90) % 360)) * this.tileHeight;
        var cos = Math.cos(thingy() * -((this.Player.Rotation + 90) % 360)) * this.tileHeight;

        var sinAOV1 = Math.sin(thingy() * -((this.Player.Rotation + 90 - (this.Player.AngleOfView / 2))) % 360) * this.tileHeight*10;
        var cosAOV1 = Math.cos(thingy() * -((this.Player.Rotation + 90- (this.Player.AngleOfView / 2))) % 360) * this.tileHeight*10;

        var sinAOV2 = Math.sin(thingy() * -((this.Player.Rotation + 90 + (this.Player.AngleOfView / 2))) % 360) * this.tileHeight*10;
        var cosAOV2 = Math.cos(thingy() * -((this.Player.Rotation + 90 + (this.Player.AngleOfView / 2))) % 360) * this.tileHeight*10;
 
        var slice = this.Player.AngleOfView  / 300;

        this.ctxfake3d.clearRect(0, 0, this.ctxfake3d.canvas.width, this.ctxfake3d.canvas.height);
        for (var i = 0; i < 300; i++) {
            var result: RayCastResult = RayCast(this.Player.Rotation - (this.Player.AngleOfView / 2) + (i * slice), this.Player.X / this.tileWidth, this.Player.Y / this.tileHeight, 0, 25, this.map, this.tileset, this.tileWidth, this.tileHeight);
            //  result.Tile.
            if (result !== undefined) {
                this.ctxfake3d.drawImage(this.bitmap,
                    result.Tile.X + result.PixelColumn/*source xoff*/,
                    result.Tile.Y/*yoff*/,
                    this.tileWidth/*width*/,
                    this.tileHeight/*height*/,
                    i/*canvas xoff*/,
                    0/*yoff*/,
                    1/*width*/,
                    this.tileHeight/*height*/);

                       //temp to test shit--->

                this.ctx.beginPath();
                this.ctx.moveTo(this.Player.X, this.Player.Y);
                this.ctx.lineTo(Math.round(result.x * this.tileWidth), Math.round(result.y * this.tileHeight));
                this.ctx.stroke();

                      //temp to test shit<---
    
            }
        }
       
      
        this.ctx.fillStyle = "#ff0000";
        this.ctx.strokeStyle = "black";

        this.ctx.beginPath();
        this.ctx.moveTo(this.Player.X, this.Player.Y);     
        this.ctx.lineTo(Math.round(this.Player.X + sin), Math.round(this.Player.Y + cos));
        this.ctx.stroke();

        this.ctx.fillStyle = "#ffff44";

        this.ctx.beginPath();
        this.ctx.moveTo(this.Player.X, this.Player.Y);
        this.ctx.lineTo(Math.round(this.Player.X + sinAOV1), Math.round(this.Player.Y + cosAOV1));
        this.ctx.stroke();

        this.ctx.beginPath();
        this.ctx.moveTo(this.Player.X, this.Player.Y);
        this.ctx.lineTo(Math.round(this.Player.X + sinAOV2), Math.round(this.Player.Y + cosAOV2));
        this.ctx.stroke();



        this.ctx.fillRect(this.Player.X - 2, this.Player.Y - 2, 3, 3);

    
    }


}


class Player {
 
    private gameWorld: Game;

    private angleOfView: number;
    public get AngleOfView(): number {
        return this.angleOfView;
    }

    private x: number;
    public get X(): number {
        if (this.x === undefined) {
            this.x = 0;
        }
        return this.x;
    }
    public set X(value: number) {
      //  if (this.x <= 0 && this.y >= this.gameWorld.Width) {
            this.x = value;
        //}
    }

    private y: number;
    public get Y(): number {      
        if (this.y === undefined) {
            this.y = 0;
        }
        return this.y;
    }
    public set Y(value: number) {
     //   if (this.y <= 0 && this.y >= this.gameWorld.Height) {
            this.y = value;
       // }
    }

    private rotation: number;
    public get Rotation(): number {
        if (this.rotation === undefined) { this.rotation = 0; } 
        return this.rotation;
    }
    public set Rotation(value: number) {
        this.rotation = <any>value % 360;
        if (this.rotation < 0) {
            this.rotation += 360
        }

        document.title = this.Rotation.toString();
    }
 
    public RigEvents(): void {
        var me = this;
        var speed = 5;
        window.addEventListener("keypress", function (event) {
            if (event.keyCode == KeyCodes.Up) {

                var x = Math.cos(me.Rotation * thingy()) * speed;
                var y = Math.sin(me.Rotation * thingy()) * speed;
                me.X -= x;
                me.Y -= y;
             } 
            if (event.keyCode == KeyCodes.Down) {
                var x = Math.cos(me.Rotation * thingy()) * speed;
                var y = Math.sin(me.Rotation * thingy()) * speed;
                me.X += x;
                me.Y += y;
            } 
            if (event.keyCode == KeyCodes.Left) {
                me.Rotation -= speed/2;

            }
            if (event.keyCode == KeyCodes.Right) {
                me.Rotation += speed/2;
            }
            window.requestAnimationFrame(function () {
                me.gameWorld.DrawMap();

            });

 
            event.preventDefault();
        },false);
    }


    public constructor(angleOfView: number, gameWorld: Game) {
        this.angleOfView = angleOfView;
        this.gameWorld = gameWorld;
        this.X = 0;
        this.Y = 0;
    }
}

enum KeyCodes {
    Up = 38,
    Down = 40,
    Left = 37,
    Right=39
}
var game: Game;
window.addEventListener("load", function () {
   // alert(90 % 360);

  

    game = new Game(129, 0, 37, 45, [
        new Tile(0, "#000000", 0, 0, TileType.NonRender),
        new Tile(1, "#ff0000", 0, 0, TileType.Normal),
        new Tile(2, "#00ff00", 32, 0, TileType.Normal),
        new Tile(3, "#ffff00", 64, 0, TileType.Sprite),
        new Tile(4, "#0000ff", 96, 0, TileType.Normal),
        new Tile(4, "#ffffff", 96, 0, TileType.Player)
    ], 32, 32);
    
    game.DrawMap();
})

