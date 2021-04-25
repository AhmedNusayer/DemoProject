Vue.component("profile-info", {
    props: ["picpath", "name", "username", "email", "address", "phonenumber", "dateofbirth"],
    data: function () {
        return {
            picturePath: this.picpath,
            dpPlaceholder: "/Images/dp_placeholder.png",
            Name: this.name,
            UserName: this.username,
            Email: this.email,
            Address: this.address,
            PhoneNumber: this.phonenumber,
            DateofBirth: this.dateofbirth,
            Intro: "",
            Educations: [],
            Education: {
                Institution: "",
                Degree: "",
                FieldOfStudy: "",
                StartDate: "",
                EndDate: "",
                Grade: ""
            },
            Experiences: [],
            Experience: {
                Title: "",
                EmploymentType: "",
                Company: "",
                Location: "",
                StartDate: "",
                EndDate: ""
            },
            forEducationUpdate: false,
            forExperenceUpdate: false
        }
    },

    methods: {
        addEducation() {
            this.Educations.push({
                Institution: this.Education.Institution, Degree: this.Education.Degree,
                FieldOfStudy: this.Education.FieldOfStudy, StartDate: this.Education.StartDate,
                EndDate: this.Education.EndDate, Grade: this.Education.Grade
            })
        },
        addExperience() {
            this.Experiences.push({
                Title: this.Experience.Title, EmploymentType: this.Experience.EmploymentType,
                Company: this.Experience.Company, Location: this.Experience.Location,
                StartDate: this.Experience.StartDate, EndDate: this.Experience.EndDate
            })
        },
        addEducationClicked() {
            this.forEducationUpdate = false
            this.Education = {}
        },
        addExperienceClicked() {
            this.forExperenceUpdate = false
            this.Experience = {}
        },
        deleteEducation() {
            var idx = this.Educations.findIndex(x => x.Institution === this.Education.Institution)
            if (idx != -1) {
                this.Educations.splice(idx, 1)
            }
        },
        deleteExperience() {
            var idx = this.Experiences.findIndex(x => x.Title === this.Experience.Title)
            if (idx != -1) {
                this.Experiences.splice(idx, 1)
            }
        },
        getEdu(edu) {
            this.forEducationUpdate = true
            this.Education = edu
        },
        getExperiance(exp) {
            this.forExperenceUpdate = true
            this.Experience = exp
        }
    }
})