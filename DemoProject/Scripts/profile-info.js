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
                Grade: "",
                EducationUUID: ""
            },
            Experiences: [],
            Experience: {
                Title: "",
                EmploymentType: "",
                Company: "",
                Location: "",
                StartDate: "",
                EndDate: "",
                ExperienceUUID: ""
            },
            Skills: [],
            Skill: "",
            Interests: [],
            Interest: {
                Title: "",
                Description: "",
                InterestUUID: ""
            },
            forEducationUpdate: false,
            forExperenceUpdate: false,
            forInterestUpdate: false
        }
    },

    methods: {
        addEducation() {
            this.Educations.push({
                Institution: this.Education.Institution, Degree: this.Education.Degree,
                FieldOfStudy: this.Education.FieldOfStudy, StartDate: this.Education.StartDate,
                EndDate: this.Education.EndDate, Grade: this.Education.Grade, EducationUUID: this.getGUID()
            })
        },
        addExperience() {
            this.Experiences.push({
                Title: this.Experience.Title, EmploymentType: this.Experience.EmploymentType,
                Company: this.Experience.Company, Location: this.Experience.Location,
                StartDate: this.Experience.StartDate, EndDate: this.Experience.EndDate, ExperienceUUID: this.getGUID()
            })
        },
        addSkill() {
            this.Skills.push(this.Skill)
        },
        addInterest() {
            this.Interests.push({
                Title: this.Interest.Title, Description: this.Interest.Description, InterestUUID: this.getGUID()
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
        addInterestClicked() {
            this.forInterestUpdate = false
            this.Interest = {}
        },

        deleteEducation(edu) {
            var idx = this.Educations.findIndex(x => x.EducationUUID === edu.EducationUUID)
            if (idx != -1) {
                this.Educations.splice(idx, 1)
            }
        },
        deleteExperience(exp) {
            var idx = this.Experiences.findIndex(x => x.ExperienceUUID === exp.ExperienceUUID)
            if (idx != -1) {
                this.Experiences.splice(idx, 1)
            }
        },
        deleteSkill(skill) {
            var idx = this.Skills.indexOf(skill)
            if (idx != -1) {
                this.Skills.splice(idx, 1)
            }
        },
        deleteInterest(interest) {
            var idx = this.Interests.findIndex(x => x.InterestUUID === interest.InterestUUID)
            if (idx != -1) {
                this.Interests.splice(idx, 1)
            }
        },

        getEdu(edu) {
            this.forEducationUpdate = true
            this.Education = edu
        },
        getExperiance(exp) {
            this.forExperenceUpdate = true
            this.Experience = exp
        },
        getInterest(interest) {
            this.forInterestUpdate = true
            this.Interest = interest
        },

        getGUID() {
            var d = new Date().getTime();
            if (typeof performance !== 'undefined' && typeof performance.now === 'function') {
                d += performance.now(); //use high-precision timer if available
            }
            var newGuid = 'xxxxxxxx-xxxx-4xxx-yxxx-xxxxxxxxxxxx'.replace(/[xy]/g, function (c) {
                var r = (d + Math.random() * 16) % 16 | 0;
                d = Math.floor(d / 16);
                return (c === 'x' ? r : (r & 0x3 | 0x8)).toString(16);
            });

            return newGuid;
        }
    }
})