Vue.component("applicant-info", {
    props: ["user", "picpath"],
    data: function () {
        return {
            User: JSON.parse(this.user),
            picturePath: this.picpath,
            dpPlaceholder: "/Images/dp_placeholder.png"
        }
    },
    methods: {
        viewcv() {
            window.location.href = '/' + this.User.UserName
        }
    }
})
