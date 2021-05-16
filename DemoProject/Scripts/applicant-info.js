Vue.component("applicant-info", {
    props: ["user"],
    data: function () {
        return {
            User: JSON.parse(this.user)
        }
    },
    methods: {
        viewcv() {
            window.location.href = '/Profile/ViewCV?userid=' + this.User.Id
        }
    }
})
