Vue.component("profile-info", {
    props: ["user", "picpath", "name", "username", "email", "address", "phonenumber", "dateofbirth",
            "intro", "knowledge", "hobby", "website", "github", "linkedin", "education"],
    data: function () {
        return {
            User: JSON.parse(this.user),
            picturePath: this.picpath,
            dpPlaceholder: "/Images/dp_placeholder.png",
            Name: this.name,
            UserName: this.username,
            Email: this.email,
            Address: this.address,
            PhoneNumber: this.phonenumber,
            DateofBirth: this.dateofbirth,
            Website: this.website,
            Github: this.github,
            Linkedin: this.linkedin,
            Hobby: this.hobby,
            Intro: this.intro,
            Knowledge: this.knowledge,
            Educations: [],
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
            Experiences: [],
            Experience: {
                Title: "",
                EmploymentType: "",
                Company: "",
                Location: "",
                StartDate: "",
                EndDate: "",
                ExperienceUUID: "",
                Description: ""
            },
            Skills: [],
            Skill: {
                SkillName: "",
                Level: 0,
                SkillUUID: ""
            },
            Interests: [],
            Interest: {
                Title: "",
                Description: "",
                InterestUUID: ""
            },
            Projects: [],
            Project: {
                Name: "",
                Platform: "",
                Year: "",
                Description: "",
                Url: "",
                ProjectUUID: ""
            },
            Contributions: [],
            Contribution: {
                Name: "",
                Description: "",
                Url: "",
                ContributionUUID: ""
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
            //this.Educations.push(this.education)
            this.Educations.push({
                Institution: this.Education.Institution, Degree: this.Education.Degree,
                FieldOfStudy: this.Education.FieldOfStudy, StartDate: this.Education.StartDate,
                EndDate: this.Education.EndDate, Grade: this.Education.Grade, GUID: this.getGUID(),
                Description: this.Educations.Description
            })
        },
        addExperience() {
            this.Experiences.push({
                Title: this.Experience.Title, EmploymentType: this.Experience.EmploymentType,
                Company: this.Experience.Company, Location: this.Experience.Location,
                StartDate: this.Experience.StartDate, EndDate: this.Experience.EndDate, ExperienceUUID: this.getGUID(),
                Description: this.Experiences.Description
            })
        },
        addSkill() {
            this.Skills.push({
                SkillName: this.Skill.SkillName, Level: this.Skill.Level, SkillUUID: this.Skill.SkillUUID
            })
        },
        addInterest() {
            this.Interests.push({
                Title: this.Interest.Title, Description: this.Interest.Description, InterestUUID: this.getGUID()
            })
        },
        addProject() {
            this.Projects.push({
                Name: this.Project.Name, Platform: this.Project.Platform, Year: this.Project.Year,
                Description: this.Project.Description, Url: this.Project.Url, ProjectUUID: this.getGUID()
            })
        },
        addContribution() {
            this.Contributions.push({
                Name: this.Contribution.Name, Description: this.Contribution.Description, Url: this.Contribution.Url,
                ContributionUUID: this.getGUID()
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
            var idx = this.Skills.findIndex(x => x.SkillUUID == skill.SkillUUID)
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
        deleteProject(project) {
            var idx = this.Projects.findIndex(x => x.ProjectUUID === project.ProjectUUID)
            if (idx != -1) {
                this.Projects.splice(idx, 1)
            }
        },
        deleteContribution(contribution) {
            var idx = this.Contributions.findIndex(x => x.ContributionUUID === contribution.ContributionUUID)
            if (idx != -1) {
                this.Contributions.splice(idx, 1)
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
        },

        update() {
            //this.user.Educations = this.Educations
            $.ajax({
                type: "POST",
                url: "/Profile/Index",
                data: {
                    model: JSON.stringify(this.Educations)
                }
            })
        }
    }
})