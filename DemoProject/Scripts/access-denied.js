Vue.component("access-denied", {
    props: ["error"],
    data: function () {
        return {
            Error: this.error
        }
    }
})