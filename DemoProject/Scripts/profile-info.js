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
            forUpdate: false
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
        addEducationClicked() {
            this.forUpdate = false
            this.Education = {}
        },
        deleteEducation() {
            this.Educations.filter(el => el.Institution != this.Education.Institution &&
                el.Degree != this.Education.Degree &&
                el.FieldOfStudy != this.Education.FieldOfStudy &&
                el.StartDate != this.Education.StartDate &&
                el.EndDate != this.Education.EndDate &&
                el.Grade != this.Education.Grade
            )
        },
        getEdu(edu) {
            this.forUpdate = true
            this.Education = edu
        }
    }
})