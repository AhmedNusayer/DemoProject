Vue.component("post-job", {
    props: ["user"],
    data: function () {
        return {
            JobTitle: "",
            JobLocation: "",
            JobType: "",
            NoOfPosts: 1,
            SalaryRangeStart: 0,
            SalaryRangeEnd: 0,
            JobDescription: "",
            User: JSON.parse(this.user)
        }
    },

    computed: {
        isDisabled() {
            if (this.JobTitle.length != 0 && this.JobLocation.length != 0 && this.NoOfPosts > 0 &&
                this.JobDescription.length != 0 && parseInt(this.SalaryRangeEnd) >= parseInt(this.SalaryRangeStart)
                && parseInt(this.SalaryRangeStart) >= 0 && parseInt(this.SalaryRangeEnd) >= 0) {
                return false;
            } else {
                return true;
            }
        },
    }
})