import "./register-company.js"
import "./profile-info.js"
import "./register-employer.js"
import "./home-page.js"
import "./privacy-page.js"
import "./register-user.js"
import "./signin-user.js"
import "./post-job.js"
import "./jobpost-card.js"
import "./job-details.js"
import "./resume-info.js"
import "./apply-form.js"
import "./notification-list.js"
import "./applicant-info.js"
import "./access-denied.js"
import "./chat-hub.js";

new Vue({
    el: "#app",
    data: {
        isTrue: true,
    },

    methods: {
        change: function () {
            this.isTrue = !this.isTrue
        }
    },
})


