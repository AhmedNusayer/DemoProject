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
            
        },
        getEdu(edu) {
            this.forUpdate = true
            this.Education = edu
        }
    }
})