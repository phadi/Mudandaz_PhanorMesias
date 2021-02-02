"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var testing_1 = require("@angular/core/testing");
var viajes_service_1 = require("./viajes.service");
describe('ViajesService', function () {
    beforeEach(function () { return testing_1.TestBed.configureTestingModule({}); });
    it('should be created', function () {
        var service = testing_1.TestBed.get(viajes_service_1.ViajesService);
        expect(service).toBeTruthy();
    });
});
//# sourceMappingURL=viajes.service.spec.js.map