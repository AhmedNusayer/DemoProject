
new Vue({
    el: "#app",
    data: {
        num1: 0,
        num2: 0,
        picked: "Summation",
    },

    computed: {
        calculate: function () {
            if (this.picked == "Summation") {
                return parseFloat(this.num1) + parseFloat(this.num2);
            } else if (this.picked == "Substraction") {
                return parseFloat(this.num1) - parseFloat(this.num2);
            } else if (this.picked == "Multiplication") {
                return parseFloat(this.num1) * parseFloat(this.num2);
            } else if (this.picked == "Division") {
                return parseFloat(this.num1) / parseFloat(this.num2);
            } else {
                return NaN;
            }
        },
    }
})
