var Grid = (function () {
    function Grid(xMax, yMax) {
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
    Grid.prototype.Get = function (x, y) {
        if (this.ary[x] !== undefined) {
            if (this.ary[x][y] !== undefined) {
                return this.ary[x][y];
            }
            else {
                return null;
            }
        }
        else {
            return null;
        }
    };
    Grid.prototype.Set = function (x, y, val) {
        this.ary[x][y] = val;
    };
    Grid.prototype.Traverse = function (func) {
        for (var y = 0; y < this.yMax; y++) {
            for (var x = 0; x < this.xMax; x++) {
                func(this.ary[x][y], x, y);
            }
        }
    };
    return Grid;
}());
var TileType;
(function (TileType) {
    TileType[TileType["Player"] = 0] = "Player";
    TileType[TileType["NonRender"] = 1] = "NonRender";
    TileType[TileType["Normal"] = 2] = "Normal";
    TileType[TileType["Sprite"] = 3] = "Sprite";
})(TileType || (TileType = {}));
var Tile = (function () {
    function Tile(id, color, x, y, type) {
        this.id = id;
        this.color = color;
        this.x = x;
        this.y = y;
        this.type = type;
    }
    Object.defineProperty(Tile.prototype, "Id", {
        get: function () {
            return this.id;
        },
        enumerable: true,
        configurable: true
    });
    Object.defineProperty(Tile.prototype, "Color", {
        get: function () {
            return this.color;
        },
        enumerable: true,
        configurable: true
    });
    Object.defineProperty(Tile.prototype, "X", {
        get: function () {
            return this.x;
        },
        enumerable: true,
        configurable: true
    });
    Object.defineProperty(Tile.prototype, "Y", {
        get: function () {
            return this.y;
        },
        enumerable: true,
        configurable: true
    });
    Object.defineProperty(Tile.prototype, "Type", {
        get: function () {
            return this.type;
        },
        enumerable: true,
        configurable: true
    });
    return Tile;
}());
function thingy() { return (Math.PI * 2) / 360; }
var RayCastResult = (function () {
    //temp to test shit<---
    function RayCastResult(pixelColumn, tile, rayLenght) {
        this.pixelColumn = pixelColumn;
        this.tile = tile;
        this.rayLenght = rayLenght;
    }
    Object.defineProperty(RayCastResult.prototype, "PixelColumn", {
        get: function () {
            return this.pixelColumn;
        },
        enumerable: true,
        configurable: true
    });
    Object.defineProperty(RayCastResult.prototype, "Tile", {
        get: function () {
            return this.tile;
        },
        enumerable: true,
        configurable: true
    });
    Object.defineProperty(RayCastResult.prototype, "RayLenght", {
        get: function () {
            return this.rayLenght;
        },
        enumerable: true,
        configurable: true
    });
    return RayCastResult;
}());
function RayCast(angle, posX, posY, step, MaxStep, map, tileset, tileWidth, tileHeight) {
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
    }
    else {
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
        }
    }
}
var Game = (function () {
    function Game(xPos, yPos, width, height, tileset, tileWidth, tileHeight) {
        this.tileWidth = tileWidth;
        this.tileHeight = tileHeight;
        this.yPos = yPos;
        this.xPos = xPos;
        this.height = height;
        this.width = width;
        this.map = new Grid(width, height);
        this.tileset = tileset;
        this.bitmap = document.getElementById("resource");
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
                var tile = this.tileset.find(function (n) { return n.Color == color; });
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
                }
                else {
                }
            }
        }
    }
    Object.defineProperty(Game.prototype, "Width", {
        get: function () {
            return this.width;
        },
        enumerable: true,
        configurable: true
    });
    Object.defineProperty(Game.prototype, "Height", {
        get: function () {
            return this.height;
        },
        enumerable: true,
        configurable: true
    });
    Object.defineProperty(Game.prototype, "XPos", {
        get: function () {
            return this.xPos;
        },
        enumerable: true,
        configurable: true
    });
    Object.defineProperty(Game.prototype, "YPos", {
        get: function () {
            return this.yPos;
        },
        enumerable: true,
        configurable: true
    });
    Game.prototype.toHex = function (nr) {
        var str = nr.toString(16);
        var pad = "00";
        return pad.substring(0, pad.length - str.length) + str;
    };
    Game.prototype.GetColor = function (x, y, ctx) {
        var data = ctx.getImageData(x, y, 1, 1).data;
        return "#" + this.toHex(data[0]) + this.toHex(data[1]) + this.toHex(data[2]);
    };
    Game.prototype.GetContext = function (id) {
        var canvas = document.getElementById(id);
        var ctx = canvas.getContext("2d");
        ctx['imageSmoothingEnabled'] = false; /* standard */
        ctx['mozImageSmoothingEnabled'] = false; /* Firefox */
        ctx['oImageSmoothingEnabled'] = false; /* Opera */
        ctx['webkitImageSmoothingEnabled'] = false; /* Safari */
        ctx['msImageSmoothingEnabled'] = false; /* IE */
        return ctx;
    };
    Game.prototype.DrawMap = function () {
        var _this = this;
        this.ctx.clearRect(0, 0, this.Width * this.tileHeight, this.Height * this.tileHeight);
        this.map.Traverse(function (tileRef, x, y) {
            var tile = _this.tileset.find(function (m) { return m.Id === tileRef; });
            if (tile.Type === TileType.Normal) {
                _this.ctx.drawImage(_this.bitmap, tile.X, tile.Y, _this.tileWidth, _this.tileHeight, x * _this.tileWidth, y * _this.tileHeight, _this.tileWidth, _this.tileHeight);
            }
        });
        var sin = Math.sin(thingy() * -((this.Player.Rotation + 90) % 360)) * this.tileHeight;
        var cos = Math.cos(thingy() * -((this.Player.Rotation + 90) % 360)) * this.tileHeight;
        var sinAOV1 = Math.sin(thingy() * -((this.Player.Rotation + 90 - (this.Player.AngleOfView / 2))) % 360) * this.tileHeight * 10;
        var cosAOV1 = Math.cos(thingy() * -((this.Player.Rotation + 90 - (this.Player.AngleOfView / 2))) % 360) * this.tileHeight * 10;
        var sinAOV2 = Math.sin(thingy() * -((this.Player.Rotation + 90 + (this.Player.AngleOfView / 2))) % 360) * this.tileHeight * 10;
        var cosAOV2 = Math.cos(thingy() * -((this.Player.Rotation + 90 + (this.Player.AngleOfView / 2))) % 360) * this.tileHeight * 10;
        var slice = this.Player.AngleOfView / 300;
        this.ctxfake3d.clearRect(0, 0, this.ctxfake3d.canvas.width, this.ctxfake3d.canvas.height);
        for (var i = 0; i < 300; i++) {
            var result = RayCast(this.Player.Rotation - (this.Player.AngleOfView / 2) + (i * slice), this.Player.X / this.tileWidth, this.Player.Y / this.tileHeight, 0, 25, this.map, this.tileset, this.tileWidth, this.tileHeight);
            //  result.Tile.
            if (result !== undefined) {
                this.ctxfake3d.drawImage(this.bitmap, result.Tile.X + result.PixelColumn /*source xoff*/, result.Tile.Y /*yoff*/, this.tileWidth /*width*/, this.tileHeight /*height*/, i /*canvas xoff*/, 0 /*yoff*/, 1 /*width*/, this.tileHeight /*height*/);
                //temp to test shit--->
                this.ctx.beginPath();
                this.ctx.moveTo(this.Player.X, this.Player.Y);
                this.ctx.lineTo(Math.round(result.x * this.tileWidth), Math.round(result.y * this.tileHeight));
                this.ctx.stroke();
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
    };
    return Game;
}());
var Player = (function () {
    function Player(angleOfView, gameWorld) {
        this.angleOfView = angleOfView;
        this.gameWorld = gameWorld;
        this.X = 0;
        this.Y = 0;
    }
    Object.defineProperty(Player.prototype, "AngleOfView", {
        get: function () {
            return this.angleOfView;
        },
        enumerable: true,
        configurable: true
    });
    Object.defineProperty(Player.prototype, "X", {
        get: function () {
            if (this.x === undefined) {
                this.x = 0;
            }
            return this.x;
        },
        set: function (value) {
            //  if (this.x <= 0 && this.y >= this.gameWorld.Width) {
            this.x = value;
            //}
        },
        enumerable: true,
        configurable: true
    });
    Object.defineProperty(Player.prototype, "Y", {
        get: function () {
            if (this.y === undefined) {
                this.y = 0;
            }
            return this.y;
        },
        set: function (value) {
            //   if (this.y <= 0 && this.y >= this.gameWorld.Height) {
            this.y = value;
            // }
        },
        enumerable: true,
        configurable: true
    });
    Object.defineProperty(Player.prototype, "Rotation", {
        get: function () {
            if (this.rotation === undefined) {
                this.rotation = 0;
            }
            return this.rotation;
        },
        set: function (value) {
            this.rotation = value % 360;
            if (this.rotation < 0) {
                this.rotation += 360;
            }
            document.title = this.Rotation.toString();
        },
        enumerable: true,
        configurable: true
    });
    Player.prototype.RigEvents = function () {
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
                me.Rotation -= speed / 2;
            }
            if (event.keyCode == KeyCodes.Right) {
                me.Rotation += speed / 2;
            }
            window.requestAnimationFrame(function () {
                me.gameWorld.DrawMap();
            });
            event.preventDefault();
        }, false);
    };
    return Player;
}());
var KeyCodes;
(function (KeyCodes) {
    KeyCodes[KeyCodes["Up"] = 38] = "Up";
    KeyCodes[KeyCodes["Down"] = 40] = "Down";
    KeyCodes[KeyCodes["Left"] = 37] = "Left";
    KeyCodes[KeyCodes["Right"] = 39] = "Right";
})(KeyCodes || (KeyCodes = {}));
var game;
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
});
