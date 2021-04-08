Vue.component("jobpost-card", {
    props: ["jobpost"],
    data: function () {
        return {
            JobPost: JSON.parse(this.jobpost)
        }
    },

    methods: {
        Redirect(id) {
            window.location.href = '/Home/JobDetails?id=' + id
        }
    }
})