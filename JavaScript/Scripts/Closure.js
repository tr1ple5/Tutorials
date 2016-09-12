
var passed = 3; // this prop will be available in the function which is technically a "closure".  using a variable from outside of the scope

var addTo = function () {
    var inner = 2;
    return passed + inner;
};

console.dir(addTo);
//console.log(addTo());