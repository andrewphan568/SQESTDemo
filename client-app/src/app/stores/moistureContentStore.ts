import { makeAutoObservable, runInAction } from "mobx";
import agent from "../agent";
import {
    MoistureContent, Preparation, Project, SourceMaterial,
    Sample, StandardTestMethod, Specification,
    WarningMessageMC
} from "../models/apiTypes";
//import { v4 as uuidv4 } from 'uuid';

export default class MoistureContentStore {
    loading = false;
    initialLoading = false;
    moistureContents: MoistureContent[] = [];
    selectedMoistureContent: MoistureContent = new MoistureContent();
    massErrors = new Map<string, WarningMessageMC>();

    deletingId = "";
    createMode = false;
    editMode = false;
    constructor() {
        makeAutoObservable(this)
    }

    loadMoistureContents = async () => {
        this.initialLoading = true;
        this.massErrors.clear();
        this.resetModes();
        try {
            const moistureContents = await agent.MoistureContents.list();
            runInAction(() => {
                this.moistureContents = moistureContents;
                this.setInitialloading(false);
            })
        } catch (error) {
            this.setInitialloading(false);
        }
    }

    loadMoistureContent = async (id: string) => {
        this.resetModes();
        this.massErrors.clear();
        let moistureContent = this.getMoistureContent(id);
        if (moistureContent) {
            this.selectedMoistureContent = moistureContent;
            return moistureContent;
        } else {
            this.initialLoading = true;
            try {
                moistureContent = await agent.MoistureContents.details(id);
                if (moistureContent) {
                    runInAction(() => {
                        this.selectedMoistureContent = moistureContent!;
                    })
                }
                this.setInitialloading(false);
                return moistureContent;
            } catch (error) {
                console.log(error);
                this.setInitialloading(false);
            }
        }
    }

    deleteMoistureContent = async (id: string) => {
        this.deletingId = id;
        this.massErrors.clear();
        try {
            await agent.MoistureContents.delete(id);
            runInAction(() => {
                var index = this.moistureContents.findIndex(m => m.id === id);
                if (index >= 0) {
                    this.moistureContents.splice(index, 1);
                }
            })
        } catch (error) {
            console.log(error);
            runInAction(() => {
                this.deletingId = "";
            })
        }
    }

    updateMoistureContent = async (moistureContent: MoistureContent) => {
        this.loading = true;
        this.massErrors.clear();
        this.resetModes();
        try {
            await agent.MoistureContents.update(moistureContent);
            runInAction(() => {
                if (moistureContent.id) {
                    var index = this.moistureContents.findIndex(m => m.id === moistureContent.id);
                    if (index >= 0) {
                        this.moistureContents[index] = moistureContent;
                    }
                    this.selectedMoistureContent = moistureContent;
                }
            })
            this.setloading(false);
        } catch (error) {
            console.log(error);
            this.setloading(false);
        }
    }

    createMoistureContent = async (moistureContent: MoistureContent) => {
        this.loading = true;
        this.massErrors.clear();
        this.createMode = true;
        try {
            await agent.MoistureContents.create(moistureContent);
            runInAction(() => {
                this.selectedMoistureContent = moistureContent;
            })
            this.setloading(false);
            this.resetModes();
        } catch (error) {
            console.log(error);
            this.setloading(false);
        }
    }

    private getMoistureContent = (id: string) => {
        return this.moistureContents.find(m => m.id === id);
    }

    setloading = (state: boolean) => {
        this.loading = state;
    }

    setEditMode = (state: boolean) => {
        this.resetModes()
        this.editMode = state;
    }

    setInitialloading = (state: boolean) => {
        this.initialLoading = state;
    }

    resetModes = () => {
        this.editMode = false;
        this.createMode = false;
    }

    setCreateMode = (state: boolean) => {
        this.resetModes()
        this.createMode = state;
        if (state) {
            var project = new Project();
            var sourceMaterial = new SourceMaterial();
            var specification = new Specification();
            var sample = new Sample();
            var preparation = new Preparation();
            var standardTestMethod = new StandardTestMethod();
            var moistureContent = new MoistureContent();

            moistureContent.project = project;
            moistureContent.sourceMaterial = sourceMaterial;
            moistureContent.specification = specification;
            moistureContent.sample = sample;
            moistureContent.preparation = preparation;
            moistureContent.standardTestMethod = standardTestMethod;
            //moistureContent.id = uuidv4();

            this.selectedMoistureContent = moistureContent;
        }
    }

    clearTestBySegment = () => {
        this.selectedMoistureContent.testerName = "";
        this.selectedMoistureContent.dateChecked = undefined;
    }
    clearRemarks = () => {
        this.selectedMoistureContent.remarks = "";
        this.selectedMoistureContent.dateChecked = undefined;
        this.selectedMoistureContent.checkerName = "";
    }

    validateMassInput = (key: string, value: any) => {
        var firstWarningMessage = new WarningMessageMC();
        // remove the previouse error in key first

        this.massErrors.clear();

        if (value! instanceof String) {
            firstWarningMessage.isError = true;
            firstWarningMessage.message = "Value should be number";
            this.selectedMoistureContent.materialDryMass = undefined;
            this.selectedMoistureContent.materialWetMass = undefined;
            this.selectedMoistureContent.waterContentPercentage = undefined;
            this.massErrors.set(key, firstWarningMessage);
        }
        else if (value === null || value === undefined || value === '0') {
            firstWarningMessage.isWarning = true;
            firstWarningMessage.message = "Tare mass is expected, a missing or 0 tare mass may indicate an issue with the result";
            this.massErrors.set(key, firstWarningMessage)
        }
        else if (value === null || value === undefined || value < 0) {
            firstWarningMessage.isError = true;
            firstWarningMessage.message = "Mass cannot be less than 0";
            this.selectedMoistureContent.materialDryMass = undefined;
            this.selectedMoistureContent.materialWetMass = undefined;
            this.selectedMoistureContent.waterContentPercentage = undefined;
            this.massErrors.set(key, firstWarningMessage)
        }
        else if (key === "tareMass" || key === "tareAndMaterialWetMass" || key === "tareAndMaterialDryMass") {
            if (this.selectedMoistureContent.tareMass >= this.selectedMoistureContent.tareAndMaterialWetMass) {
                firstWarningMessage.isError = true;
                this.selectedMoistureContent.materialWetMass = undefined;
                this.selectedMoistureContent.waterContentPercentage = undefined;
                firstWarningMessage.message = "Tare and wet mass must be greater than tare mass,cannot calculate a result";

                this.massErrors.set("tareAndMaterialWetMass", firstWarningMessage)
            }
            else if (this.selectedMoistureContent.tareMass >= this.selectedMoistureContent.tareAndMaterialDryMass) {
                firstWarningMessage.isError = true;
                this.selectedMoistureContent.materialDryMass = undefined;
                this.selectedMoistureContent.waterContentPercentage = undefined;
                firstWarningMessage.message = "Tare and dry mass must be greater than tare mass, cannot calculate a result";
                this.massErrors.set("tareAndMaterialDryMass", firstWarningMessage)
            }
            else if (this.selectedMoistureContent.tareAndMaterialDryMass > this.selectedMoistureContent.tareAndMaterialWetMass) {
                firstWarningMessage.isError = true;
                this.selectedMoistureContent.waterContentPercentage = undefined;
                firstWarningMessage.message = "Dry mass greater than wet mass, cannot calculate a result";
                this.massErrors.set("tareAndMaterialDryMass", firstWarningMessage)
            }
            else {
                this.selectedMoistureContent.materialDryMass =
                    this.selectedMoistureContent.tareAndMaterialDryMass - this.selectedMoistureContent.tareMass;

                this.selectedMoistureContent.materialWetMass =
                    this.selectedMoistureContent.tareAndMaterialWetMass - this.selectedMoistureContent.tareMass;
            }
        }

        if (!firstWarningMessage.isError) {
            this.cacultateWaterContent();
        }
        else {
            this.selectedMoistureContent.waterContentPercentage = undefined;
        }
    }

    cacultateWaterContent = () => {
        if (this.selectedMoistureContent.tareAndMaterialDryMass - this.selectedMoistureContent.tareMass > 0) {
            this.selectedMoistureContent.waterContentPercentage =
                (this.selectedMoistureContent.tareAndMaterialWetMass - this.selectedMoistureContent.tareAndMaterialDryMass) * 100
                / (this.selectedMoistureContent.tareAndMaterialDryMass - this.selectedMoistureContent.tareMass);
        } else {
            this.selectedMoistureContent.waterContentPercentage = undefined;
        }
    }

    changeInfo = (newValue: any, key: string, extraKey?: string) => {
        console.log(newValue);
        // TestSubjectSegment
        if (extraKey === "TestSubjectSegment") {
            if (!this.selectedMoistureContent.standardTestMethod) {
                this.selectedMoistureContent.standardTestMethod = new StandardTestMethod();
            }
            if (!this.selectedMoistureContent.project) {
                this.selectedMoistureContent.project = new Project();
            }
            if (!this.selectedMoistureContent.sample) {
                this.selectedMoistureContent.sample = new Sample();
            }
            if (!this.selectedMoistureContent.sourceMaterial) {
                this.selectedMoistureContent.sourceMaterial = new SourceMaterial();
            }
            if (!this.selectedMoistureContent.specification) {
                this.selectedMoistureContent.specification = new Specification();
            }

            if (key === "worksheetId") {
                this.selectedMoistureContent.worksheetId = newValue;
            }
            else if (key === "standardTestMethod.code") {
                this.selectedMoistureContent.standardTestMethod.code = newValue;
            }
            else if (key === "standardTestMethod.name") {
                this.selectedMoistureContent.standardTestMethod.name = newValue;
            }
            else if (key === "projectCode") {
                this.selectedMoistureContent.project.code = newValue;
            }
            else if (key === "projectName") {
                this.selectedMoistureContent.project.name = newValue;
            }
            else if (key === "sampledDate") {
                this.selectedMoistureContent.sample.sampledDate = newValue;
            }
            else if (key === "sampledBy") {
                this.selectedMoistureContent.sample.sampledBy = newValue;
            }
            else if (key === "sourceMaterialName") {
                this.selectedMoistureContent.sourceMaterial.sourceName = newValue;
            }
            else if (key === "sourceMaterialDesciption") {
                this.selectedMoistureContent.sourceMaterial.materialDesciption = newValue;
            }
            else if (key === "specificationName") {
                this.selectedMoistureContent.specification.name = newValue;
            }
        }

        //Preparation Segment
        else if (extraKey === "PreparationSegment") {
            if (!this.selectedMoistureContent.preparation) {
                this.selectedMoistureContent.preparation = new Preparation();
            }
            if (key === "selectMethod") {
                this.selectedMoistureContent.preparation.method = newValue;
            }
            else if (key === "dryingtemperature") {
                this.selectedMoistureContent.preparation.dryingTemperature = newValue;
            }
            else if (key === "balanceEquipment") {
                this.selectedMoistureContent.preparation.balance = newValue;
            }
            else if (key === "visualNominalParticleSize") {
                this.selectedMoistureContent.preparation.visualNomialPraticalSize = newValue;
            }
            else if (key === "balanceEquipment") {
                this.selectedMoistureContent.preparation.balance = newValue;
            }
            else if (key === "toggleMaterialExcluded") {
                this.selectedMoistureContent.preparation.materialExcluded = "temptValue";
            }
            else if (key === "materialExcluded") {
                this.selectedMoistureContent.preparation.materialExcluded = newValue;
            }
            else if (key === "ovenEquipment") {
                this.selectedMoistureContent.preparation.oven = newValue;
            }
        }

        //Measurements Segment
        else if (extraKey === "MeasurementsSegment") {
            if (key === "tareId") {
                this.selectedMoistureContent.tareId = newValue;
            }
            else if (key === "tareMass") {
                this.selectedMoistureContent.tareMass = newValue;
                this.validateMassInput("tareMass", newValue);

            }
            else if (key === "tareAndMaterialWetMass") {
                this.selectedMoistureContent.tareAndMaterialWetMass = newValue;
                this.validateMassInput("tareAndMaterialWetMass", newValue)
            }

        }

        //TestedBySegment
        else if (extraKey === "TestedBySegment") {
            if (key === "testerName") {
                this.selectedMoistureContent.testerName = newValue;
            }
            else if (key === "dateTested") {
                this.selectedMoistureContent.dateTested = newValue;
            }
        }

        //DryMassSegment
        else if (extraKey === "DryMassSegment") {
            if (key === "tareAndMaterialDryMass") {
                this.selectedMoistureContent.tareAndMaterialDryMass = newValue;
                this.validateMassInput("tareAndMaterialDryMass", newValue)
            }
            else if (key === "dryMassBalance") {
                this.selectedMoistureContent.preparation.balance = newValue;// temporarily use the same balance equipment
            }
        }

        //ResultsSegment
        else if (extraKey === "ResultsSegment") {
            if (key === "selectInsufficientSampleMass") {
                this.selectedMoistureContent.selectInsufficientSampleMass = !this.selectedMoistureContent.selectInsufficientSampleMass;
            }
            else if (key === "selectMaterialExcluded") {
                this.selectedMoistureContent.selectMaterialExcluded = !this.selectedMoistureContent.selectMaterialExcluded;
            }
            else if (key === "selectDryingTemperature") {
                this.selectedMoistureContent.selectDryingTemperature = !this.selectedMoistureContent.selectDryingTemperature;
            }
        }

        else if (extraKey === "RemarksSegment") {
            if (key === "checkedBy") {
                this.selectedMoistureContent.checkerName = newValue;
            }
            else if (key === "dateChecked") {
                this.selectedMoistureContent.dateChecked = newValue;
            }
            else if (key === "remarkContent") {
                this.selectedMoistureContent.remarks = newValue;
            }
        }
    }
}


