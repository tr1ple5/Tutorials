

var peopleDynamicProto = function (name, age, state) {
    this.age = age;
    this.name = name;
    this.state = state;

    if (typeof this.printPerson !== "function") {
        peopleDynamicProto.prototype.printPerson = function () {
            console.log(this.age + ", " + this.name + ", " + this.state); // "this" to access
        };
    }
};

person1 = new peopleDynamicProto("Derrick", 35, "CA");
person2 = new peopleDynamicProto("Kimi", 29, "CA");

person1.printPerson();
person2.printPerson();
