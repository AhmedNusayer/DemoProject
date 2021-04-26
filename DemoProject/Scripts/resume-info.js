Vue.component("resume-info", {
    props: ["user"],
    data: function () {
        return {
            User: JSON.parse(this.user)
        }
    }
})
