var Class = {
    create: function () {
        var klass = function() {
            if (this.initialize) {
                this.initialize.apply(this, arguments);
            }
        };

        if (arguments.length == 2) {
            var superClass = arguments[0];

            var Inheritance = function () { };
            Inheritance.prototype = superClass.prototype;

            klass.prototype = new Inheritance();
            klass.prototype.constructor = this;
            klass.prototype.superClass = superClass.prototype;

            $.extend(klass.prototype, arguments[1]);
        }
        else {
            klass.prototype = arguments[0];
        }

        return klass;
    }
};