var PageView = Class.extend({

    init: function (pageData, history) {
        this.pageData = pageData;
        this.history = history;
        this.baseUrl = pageData.baseUrl;
        this.isAccountCreated = pageData.isAccountCreated;
        this.stepIndex = ko.observable(pageData.step);
        this.steps = this.createSteps();
        this.step = ko.computed(this.getCurrentStep, this);

        for (var i = 0; i < pageData.step; i++) {
            this.steps[i].isCompleted(true);
        }

        history.Adapter.bind(window, 'statechange', function () {
            var state = history.getState();
            var match = state.url.match(/step=(\d)/);
            var step;
            if (match) {
                step = parseInt(match[1], 10);
            } else {
                step = 0;
            }
            this.showStep(step);
        }.bind(this));
    },

    createSteps: function () {
        return [
            new CreateAccountView(this, this.pageData.invitationCode, this.pageData.contractorName),
            new SkillsView(this),
            new WorkExperiencesView(this),
            new RequirementsView(this),
            new FinishView(this)
        ];
    },

    getCurrentStep: function () {
        var index = this.stepIndex();
        return this.steps[index];
    },

    stepTemplate: function () {
        return this.step().templateId;
    },

    showNextStep: function () {
        var currentIndex = this.stepIndex();
        this.history.pushState(null, null, "?step=" + (1 + currentIndex));
    },

    showStep: function (stepIndex) {
        this.steps.forEach(function (step, index) {
            step.isCompleted(index < stepIndex);
        });
        this.stepIndex(stepIndex);
    }

});