
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
console.log(addToThis.call(obj, 3, 2, 1)); // functionName.call(obj, function arguments)