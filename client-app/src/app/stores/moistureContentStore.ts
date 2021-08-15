import { makeAutoObservable, runInAction } from "mobx";
import agent from "../agent";
import {
    MoistureContent, Preparation, Project, SourceMaterial,
    Sample, StandardTestMethod, Specification
} from "../models/apiTypes";

export default class MoistureContentStore {
    loading = false;
    initialLoading = false;
    moistureContents: MoistureContent[] = [];
    selectedMoistureContent: MoistureContent = new MoistureContent();
    createMode = false;
    constructor() {
        makeAutoObservable(this)
    }

    loadMoistureContents = async () => {
        this.initialLoading = true;
        try {
            const moistureContents = await agent.MoistureContents.list();
            runInAction(() => {
                this.createMode = false;
                this.moistureContents = moistureContents;
                this.setInitialloading(false);
            })
        } catch (error) {
            this.setInitialloading(false);
        }
    }

    loadMoistureContent = async (id: string) => {
        this.createMode = false;
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
        }
    }

    updateMoistureContent = async (moistureContent: MoistureContent) => {
        this.loading = true;
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
        try {
            await agent.MoistureContents.create(moistureContent);
            runInAction(() => {
                this.selectedMoistureContent = moistureContent;
            })
            this.setloading(false);
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

    setInitialloading = (state: boolean) => {
        this.initialLoading = state;
    }

    setCreateMode = (state: boolean) => {
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

            this.selectedMoistureContent = moistureContent;

        }
    }

    changeInfo = async (newValue: any, key: string, extraKey?: string) => {
        console.log(newValue);
        if (key === "checkedBy") {
            this.selectedMoistureContent.checkerName = newValue;
        }
        else if (key === "dateChecked") {
            this.selectedMoistureContent.dateChecked = newValue;
        }
        else if (key === "remarkContent") {
            this.selectedMoistureContent.remarks = newValue;
        }
        else if (key === "selectInsufficientSampleMass") {
            this.selectedMoistureContent.selectInsufficientSampleMass = !this.selectedMoistureContent.selectInsufficientSampleMass;
        }
        else if (key === "selectMaterialExcluded") {
            this.selectedMoistureContent.selectMaterialExcluded = !this.selectedMoistureContent.selectMaterialExcluded;
        }
        else if (key === "selectDryingTemperature") {
            this.selectedMoistureContent.selectDryingTemperature = !this.selectedMoistureContent.selectDryingTemperature;
        }
        else if (key === "tareAndMaterialDryMass") {
            this.selectedMoistureContent.tareAndMaterialDryMass = newValue;
        }
        else if (key === "tareMass") {
            this.selectedMoistureContent.tareMass = newValue;
        }
        else if (key === "tareAndMaterialWetMass") {
            this.selectedMoistureContent.tareAndMaterialWetMass = newValue;
        }
        else if (key === "selectMethod") {
            if (!this.selectedMoistureContent.preparation) {
                this.selectedMoistureContent.preparation = new Preparation();
            }
            this.selectedMoistureContent.preparation.method = newValue;
        }
        else if (key === "tareAndMaterialDryMass") {
            this.selectedMoistureContent.tareAndMaterialDryMass = newValue;
        }

    }
}


