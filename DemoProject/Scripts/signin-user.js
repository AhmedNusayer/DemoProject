Vue.component("signin-user", {
    props: ["error"],
    data: function () {
        return {
            Email: "",
            Password: "",
            Error: this.error
        }
    }
})