Vue.component("jobpost-card", {
    props: ["jobpost", "sort"],
    data: function () {
        return {
            JobPost: JSON.parse(this.jobpost),
            Sort: this.sort
        }
    },

    methods: {
        Redirect(id) {
            window.location.href = '/Home/JobDetails?id=' + id
        }
    }
})