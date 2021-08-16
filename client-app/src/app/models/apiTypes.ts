export interface Specification {
    id: string;
    name: string;
    code: string;
    createdAtUtc: Date;
    updatedAtUtc: Date;
}

export class Specification implements Specification {
    constructor(init?: Specification) {
        Object.assign(this, init);
    }
}

export interface Project {
    id: string;
    name: string;
    code: string;
    createdAtUtc: Date;
    updatedAtUtc: Date;
}

export class Project implements Project {
    constructor(init?: Project) {
        Object.assign(this, init);
    }
}


export interface SourceMaterial {
    id: string;
    sourceName: string;
    materialDesciption: string;
    createdAtUtc: Date;
    updatedAtUtc: Date;
}

export class SourceMaterial implements SourceMaterial {
    constructor(init?: SourceMaterial) {
        Object.assign(this, init);
    }
}

export interface Sample {
    id: string;
    name: string;
    sampledBy: string;
    sampledDate: Date;
    project: Project;
    createdAtUtc: Date;
    updatedAtUtc: Date;
}

export class Sample implements Sample {
    constructor(init?: Sample) {
        Object.assign(this, init);
    }
}


export interface StandardTestMethod {
    id: string;
    code: string;
    name: string;
    description: string;
    createdAtUtc: Date;
    updatedAtUtc: Date;
}

export class StandardTestMethod implements StandardTestMethod {
    constructor(init?: StandardTestMethod) {
        Object.assign(this, init);
    }
}

export interface MoistureContent {
    id: string;
    worksheetId: string;
    project: Project;
    sourceMaterial: SourceMaterial;
    specification: Specification;
    sample: Sample;
    preparation: Preparation;
    standardTestMethod: StandardTestMethod;
    tareId: string;
    tareMass: number;
    tareAndMaterialWetMass: number;
    tareAndMaterialDryMass: number;
    materialDryMass: number | undefined;
    materialWetMass: number | undefined;
    waterContentPercentage: number | undefined;
    selectInsufficientSampleMass: boolean;
    selectDryingTemperature: boolean;
    selectMaterialExcluded: boolean;
    testerName: string;
    dateTested: Date | undefined;
    remarks?: any;
    checkerName: string;
    dateChecked: Date | undefined;
}

export class MoistureContent implements MoistureContent {
    constructor(init?: MoistureContent) {
        Object.assign(this, init);
    }
}

export interface Balance {
    id: string;
    name: string;
    code: string;
    manufactureDate: Date;
    createdAtUtc: Date;
    updatedAtUtc: Date;
}
export class Balance implements Balance {
    constructor(init?: Balance) {
        Object.assign(this, init);
    }
}

export interface Oven {
    id: string;
    name: string;
    code: string;
    manufactureDate: Date;
    createdAtUtc: Date;
    updatedAtUtc: Date;
}

export class Oven implements Oven {
    constructor(init?: Oven) {
        Object.assign(this, init);
    }
}

export interface Preparation {
    id: string;
    method: string;
    dryingTemperature: number;
    balance: Balance;
    oven: Oven;
    visualNomialPraticalSize: string;
    materialExcluded?: any;
    createdAtUtc: Date;
    updatedAtUtc: Date;
}
export class Preparation implements Preparation {
    constructor(init?: Preparation) {
        Object.assign(this, init);
    }
}

export interface WarningMessageMC {
    isError?: boolean;
    isWarning?: boolean;
    message?: string;
}
export class WarningMessageMC implements WarningMessageMC {
    constructor(init?: WarningMessageMC) {
        Object.assign(this, init);
    }
}


