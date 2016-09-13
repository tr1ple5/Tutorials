
/*
var obj = { num: 2 };

var addToThis = function (a) {
    return this.num + a;
};

console.log(addToThis.call(obj, 3)); // functionName.call(obj, function arguments)
*/


var obj = { num: 2 };

var addToThis = function (a,b,c) {
    return this.num + a + b + c;

};
//call
console.log(addToThis.call(obj, 3, 2, 1)); // functionName.call(obj, function arguments)

//apply
var array = [3, 2, 1];
console.log(addToThis.apply(obj, array)); // functionName.apply(obj, function ARRAY arguments)


//bind
var bound = addToThis.bind(obj);

console.log(bound(3, 2, 1));
