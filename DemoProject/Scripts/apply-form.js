Vue.component("apply-form", {
    props: ["postid"],
    data: function () {
        return {
            PostId: this.postid
        }
    },

    methods: {
        SubmitForm() {
            window.location.href = '/Home/Submit?postid=' + this.PostId
        }
    }
})