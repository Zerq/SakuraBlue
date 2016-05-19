//function OmniBase() {


//}
//List.prototype = new OmniBase();
function List(ary, type) {

    if (ary !== undefined) {
        var array = ary;
    }
    else {
        array = [];
    }

    this.ListContentType = type;

    this.TypeCheck = function (item) {

        if (this.ListContentType === undefined) {
            return true; // not typed
        }


        if (item instanceof this.ListContentType) {
            return true;
        }
        else {
            throw new Error("incompatible type cannot add to list");
            return false;
        }
    };

    if (array === undefined) {
        array = [];
    }

    this.Select = function (selection) {
        var temp = [];
        for (var i = 0; i < array.length; i++) {
            temp.push(selection(array[i]));
        }

        return new List(temp);
    };
    this.ToArray = function () {

        return array.slice();
    };
    this.Get = function (index) {
        return array[index];
    };


    // this.TypeCheck = function (item) { alert("test");};

    this.Add = function (item) {


        if (this.TypeCheck(item)) {
            array.push(item);
        }


    };
    this.AddUnique = function (item) {
        if (this.TypeCheck(item)) {
            if (!array.Contains(item)) {
                array.push(item);
            }
        }
    };
    this.AddRange = function (items) {
        for (var i = 0; i < items.length; i++) {
            if (this.TypeCheck(items[i])) {
                this.Add(items[i]);
            }
        }
    }
    this.AddUniqueRange = function () {
        for (var i = 0; i < items.length; i++) {
            if (this.TypeCheck(items[i])) {
                if (!array.Contains(items[i])) {
                    this.AddUnique(items[i]);
                }
            }
        }
    };
    this.IndexOf = function (item) {
        return array.IndexOf(item);
    };
    this.Remove = function (item) {
        if (array.indexOf(item) != -1) {
            array.splice(i, 1);
        }
    };
    this.RemoveRange = function (items) {
        for (var i = 0; i < array.length; i++) {
            if (array.indexOf(items[i]) != -1) {
                array.splice(i, 1);
            }
        }
    };
    this.Count = function () {
        return array.length;
    }

    this.OrderByAsc = function (selectfunc) {
        array.sort(function (a, b) {
  
    

            if (selectfunc(a) < selectfunc(b)) { return -1; }
            if (selectfunc(a) > selectfunc(b)) { return 1; }
        });
        return this;
    };
    
    this.OrderByDesc = function (selectfunc) {
        array.sort(function (a, b) {
            if (selectfunc(a) > selectfunc(b)) { return -1; }
            if (selectfunc(a) < selectfunc(b)) { return 1; }
        });
        return this;
    };


    this.ForEach = function (fnc) {
        array.forEach(fnc);
    };
}


List.prototype.Where = function (criteria) {
    var result = new List();
    for (var i = 0; i < this.Count() ; i++) {
        if (criteria(this.Get(i))) {
            result.Add(this.Get(i));
        }
    }
    result.ListContentType = this.ListContentType;
    return result;
};

List.prototype.Contains = function (item) {
    for (var i = 0; i < this.Count() ; i++) {
        if (this.Get(i) === item) {
            return true;
        }
    }
    return false;
};

//List.prototype.ForEach = function (eachFunc) {

//    //for (var i = 0; i < this.Count(); i++) {
//    //   eachFunc(this.Get(i));
//    //}
//};