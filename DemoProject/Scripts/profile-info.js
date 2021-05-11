Vue.component("profile-info", {
    props: ["user", "picpath"],
    data: function () {
        return {
            UserInfo: JSON.parse(this.user),
            User: "",
            picturePath: this.picpath,
            dpPlaceholder: "/Images/dp_placeholder.png",
            Password: null,
            File: null,
            Education: {
                Institution: "",
                Degree: "",
                FieldOfStudy: "",
                StartDate: "",
                EndDate: "",
                Grade: "",
                GUID: "",
                Description: ""
            },
            Experience: {
                Title: "",
                EmploymentType: "",
                Company: "",
                Location: "",
                StartDate: "",
                EndDate: "",
                GUID: "",
                Description: ""
            },
            Skill: {
                SkillName: "",
                Level: 0,
                GUID: ""
            },
            Interest: {
                Title: "",
                Description: "",
                GUID: ""
            },
            Project: {
                Name: "",
                Platform: "",
                Year: "",
                Description: "",
                Url: "",
                GUID: ""
            },
            Contribution: {
                Name: "",
                Description: "",
                Url: "",
                GUID: ""
            },
            forEducationUpdate: false,
            forExperenceUpdate: false,
            forInterestUpdate: false,
            forProjectUpdate: false,
            forContributionUpdate: false
        }
    },

    methods: {
        addEducation() {
            this.UserInfo.Educations.push({
                Institution: this.Education.Institution,
                Degree: this.Education.Degree,
                FieldOfStudy: this.Education.FieldOfStudy,
                StartDate: this.Education.StartDate,
                EndDate: this.Education.EndDate,
                Grade: this.Education.Grade,
                Description: this.Education.Description
            })
        },
        addExperience() {
            this.UserInfo.Experiences.push({
                Title: this.Experience.Title,
                EmploymentType: this.Experience.EmploymentType,
                Company: this.Experience.Company,
                Location: this.Experience.Location,
                StartDate: this.Experience.StartDate,
                EndDate: this.Experience.EndDate,
                Description: this.Experience.Description
            })
        },
        addSkill() {
            this.UserInfo.Skills.push({
                SkillName: this.Skill.SkillName,
                Level: this.Skill.Level,
            })
        },
        addInterest() {
            this.UserInfo.Interests.push({
                Title: this.Interest.Title,
                Description: this.Interest.Description,
            })
        },
        addProject() {
            this.UserInfo.Projects.push({
                Name: this.Project.Name, Platform: this.Project.Platform, Year: this.Project.Year,
                Description: this.Project.Description, Url: this.Project.Url
            })
        },
        addContribution() {
            this.UserInfo.Contributions.push({
                Name: this.Contribution.Name, Description: this.Contribution.Description,
                Url: this.Contribution.Url
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
        addProjectClicked() {
            this.forProjectUpdate = false
            this.Project = {}
        },
        addContributionClicked() {
            this.forContributionUpdate = false
            this.Contribution = {}
        },

        deleteEducation(edu) {
            var idx = this.UserInfo.Educations.findIndex(x => x.GUID === edu.GUID)
            if (idx != -1) {
                this.UserInfo.Educations.splice(idx, 1)
            }
        },
        deleteExperience(exp) {
            var idx = this.UserInfo.Experiences.findIndex(x => x.GUID === exp.GUID)
            if (idx != -1) {
                this.UserInfo.Experiences.splice(idx, 1)
            }
        },
        deleteSkill(skill) {
            var idx = this.UserInfo.Skills.findIndex(x => x.GUID == skill.GUID)
            if (idx != -1) {
                this.UserInfo.Skills.splice(idx, 1)
            }
        },
        deleteInterest(interest) {
            var idx = this.UserInfo.Interests.findIndex(x => x.GUID === interest.GUID)
            if (idx != -1) {
                this.UserInfo.Interests.splice(idx, 1)
            }
        },
        deleteProject(project) {
            var idx = this.UserInfo.Projects.findIndex(x => x.GUID === project.GUID)
            if (idx != -1) {
                this.UserInfo.Projects.splice(idx, 1)
            }
        },
        deleteContribution(contribution) {
            var idx = this.UserInfo.Contributions.findIndex(x => x.GUID === contribution.GUID)
            if (idx != -1) {
                this.UserInfo.Contributions.splice(idx, 1)
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
        getProject(project) {
            this.forProjectUpdate = true
            this.Project = project
        },
        getContribution(contribution) {
            this.forContributionUpdate = true
            this.Contribution = contribution
        },

        /*getGUID() {
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
        },*/

        updatePic() {
            var formData = new window.FormData();
            var file = document.getElementById("fileId").files[0];
            formData.append("file", file);
            var self = this
            $.ajax({
                type: "POST",
                url: "/Profile/AddPicture",
                data: formData,
                processData: false,
                contentType: false,
                success: function (result) {
                    alert(result)
                    self.picturePath = result
                },
                async: false
            })
        },

        update() {
            var self = this
            var B = {
                UserDetails: self.UserInfo,
                Password: self.Password
            }

            $.ajax({
                type: "POST",
                url: "/Profile/UpdateProfile",
                data: {
                    model: B
                },
                success: function (result) {
                    window.location.href = result
                },
            })
        },
    }
})