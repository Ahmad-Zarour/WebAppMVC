
class ReactApplication extends React.Component {
    constructor(props) {
        super(props);
        this.state =
        {
            personData: [],
            personLanguages: [],
            joinPersonLanguage: [],
            availableCountries: [],
            availableCities: [],
            personName: '',
            personPhoneNumber: '',
            personCity: 'NotSelected',
            enabled: false,
        };
        this.GetDataFromDatabase();
    }

    /// Get the data 
    GetDataFromDatabase() {
        ///Get List person
        axios.get('React/GetListPerson')
            .then(resp => {
                var data = JSON.parse(resp.data);
                var tempArrayPerson = new Array(data.length);
                for (let i = 0; i < data.length; i++)
                    tempArrayPerson[i] =
                    {
                        personId: data[i].PersonId, fullName: data[i].FullName,
                        phoneNumber: data[i].PhoneNumber, cityId: data[i].CityId
                    };
                this.setState({ personData: tempArrayPerson });
            });

        /// Get cities
        axios.get('React/GetListCities')
            .then(resp => {
                var data = JSON.parse(resp.data);
                var tempArrayCities = new Array(data.length);
                for (let i = 0; i < data.length; i++)
                    tempArrayCities[i] =
                    {
                        cityId: data[i].CityId,
                        cityName: data[i].CityName, countryId: data[i].CountryId
                    };
                this.setState({ availableCities: tempArrayCities });
            });

        // Get Languages
        axios.get('React/GetListLanguages')
            .then(resp => {
                var data = JSON.parse(resp.data);
                var tempArraylanguage = new Array(data.length);
                for (let i = 0; i < data.length; i++)
                    tempArraylanguage[i] =
                    {
                        languageName: data[i].LanguageName, languageId: data[i].LanguageId
                    };
                this.setState({ personLanguages: tempArraylanguage });
            });

        // Get PersonLanguage
        axios.get('React/GetListPersonLanguage')
            .then(resp => {
                var data = JSON.parse(resp.data);
                var tempArrayPersonLanguage = new Array(data.length);
                for (let i = 0; i < data.length; i++)
                    tempArrayPersonLanguage[i] =
                    {
                        personId: data[i].PersonId, languageId: data[i].LanguageId
                    };
                this.setState({ joinPersonLanguage: tempArrayPersonLanguage });
            });

        /// Get Countries
        axios.get('React/GetListCountries')
            .then(resp => {
                var data = JSON.parse(resp.data);
                var tempArrayCountries = new Array(data.length);
                for (let i = 0; i < data.length; i++)
                    tempArrayCountries[i] =
                    {
                        countryName: data[i].CountryName, countryId: data[i].CountryId
                    };
                this.setState({ availableCountries: tempArrayCountries });
            });
    }


    /// methods to get country/city for a person
    GetResidence(personCityId, allCities, allCountries) {
        for (let i = 0, len = allCities.length; i < len; i++)
            for (let j = 0; j < allCountries.length; j++)
                if (personCityId == allCities[i].cityId && allCountries[j].countryId == allCities[i].countryId)
                    return allCities[i].cityName + '/' + allCountries[j].countryName;
        return null;
    }

    //Get Person Languages
    GetLanguage(person, allLanguages, personLanguage) {
        var result = 'Spoken Language :  ';
        for (let i = 0; i < personLanguage.length; i++)
            for (let j = 0; j < allLanguages.length; j++)
                if ((allLanguages[j].languageId == personLanguage[i].languageId)
                    && (personLanguage[i].personId == person.personId))
                    result += allLanguages[j].languageName + ' , ';
        return result;
    }

    //Detelet person 
    DeletePerson() {
        $.post("/React/DeletePerson", { personId: this.state.personId });
        this.RemovePersonFromList();
        this.setState({
            personInformation: '', residenceInformation: '',
            resultLanguage: '', enabled: false
        });
    }

    //Get details of a person
    GetPersonDetails(person, allCities, allCountries, allLanguages, personLanguage) {
        var personInformation = 'ID : ' + person.personId + '   / Full Name : ' + person.fullName + '   / PhoneNumber : ' + person.phoneNumber;
        var residenceInformation = ' Residence : ' + this.GetResidence(person.cityId, allCities, allCountries);
        var resultLanguage = this.GetLanguage(person, allLanguages, personLanguage);
        this.setState({ personInformation, residenceInformation, resultLanguage, personId: person.personId, enabled: true });
    }

    ////// sort the table content by person’s name from A to Z
    SortByPersonName() {
        var result = this.state.personData.sort((A, Z) => A.fullName.localeCompare(Z.fullName));
        this.setState({ personData: result });
    }

    //// for details information
    ShowContent() {
        if (this.state.enabled == true)
            return true;
        return false;
    }

    SetPersonName = set => {
        this.setState({ personName: set.target.value });
    }
    SetPersonPhoneNumber = set => {
        this.setState({ personPhoneNumber: set.target.value });
    }
    SetPersonCountry = set => {
        this.setState({ personCountry: set.target.value });
    }
    SetPersonCity = set => {
        this.setState({ personCity: set.target.value });
    }

    SavePerson = save => {
        save.preventDefault();
        var inputID = this.state.personName;
        if (this.state.personName.length > 0 && this.state.personPhoneNumber.length > 0
            && this.state.personCity != 'NotSelected') {
            this.setState({ errorMsg: '' });
            $.post("/React/CreatePerson", { fullName: this.state.personName, phoneNumber: this.state.personPhoneNumber, city: this.state.personCity }, function (data) {
                this.InsertPersonToList(data);
            }.bind(this));
        }
    }

    // Insert the person data to the list
    InsertPersonToList(person) {
        var PersonList = this.state.personData;
        PersonList.push({ personId: person.personId, fullName: person.fullName, cityId: person.cityId, phoneNumber: person.phoneNumber });
        this.setState({ personData: PersonList });
    }

    // remove person for the list
    RemovePersonFromList() {
        var PersonList = this.state.personData;
        for (var i = 0; i < this.state.personData.length; i++)
            if (PersonList[i].personId == this.state.personId)
                PersonList.splice(i, 1);
        this.setState({ personData: PersonList });
    }


    //Rendering part

    render() {
        //data for country and city list
        let AvailableCountryList = this.state.availableCountries.map(countries => {
            return (<option value={countries.countryId}>{countries.countryName}</option>)
        });
        let AvailableCityList = this.state.availableCities.map(cities => {
            if (cities.countryId == this.state.personCountry)
                return (<option value={cities.cityId}>{cities.cityName}</option>)
        });


        let personInfo = this.state.personData.map(x => {
            return (
                <tr>
                    <td>{x.personId}</td>
                    <td>{x.fullName}</td>
                    <td>{x.phoneNumber}</td>
                    <td>
                        <button className="btn btn-primary" onClick={() => this.GetPersonDetails(x, this.state.availableCities, this.state.availableCountries, this.state.personLanguages, this.state.joinPersonLanguage)}>Details</button>
                    </td>
                </tr>)
        });

        return (
            <div>
                <div>
                    <div className="col-md-8 offset-md-2">
                        <h4> List Of Person </h4>
                        <button className="btn btn-outline-primary" onClick={() => this.SortByPersonName()}>Alphabetical order </button>
                        <table className="table">
                            <thead>
                                <tr className="col-md-8 offset-md-2">
                                    <th>ID</th>
                                    <th>Person Name</th>
                                    <th>Phone Number</th>
                                    <th>Action</th>
                                </tr>
                            </thead>
                            <tbody>
                                {personInfo}
                            </tbody>
                        </table>
                    </div>
                </div>
                <div className="col-md-8 offset-md-2">
                    <table className="table">
                        <thead>
                            <tr className="col-md-8 offset-md-2">
                                {this.ShowContent() ? <th>Person Full Details</th> : <></>}
                            </tr>
                        </thead>
                        <tbody>
                            <tr>
                                <div>
                                    {this.ShowContent() ? <button className="btn btn-danger" variant="primary" size="sm" onClick={() => this.DeletePerson()}>Delete</button> : <></>}

                                </div>
                            </tr>
                            <tr>
                                {this.state.personInformation}
                            </tr>
                            <tr>
                                {this.state.residenceInformation}
                            </tr>
                            <tr>
                                {this.state.resultLanguage}
                            </tr>
                        </tbody>
                    </table>
                </div>
                <div>
                    <form onSubmit={this.SavePerson}>
                        <h3>Add New Person</h3>
                        <table className="table table-hover">
                            <thead>
                            </thead>
                            <tbody>
                                <tr>
                                    <td>
                                        <label>Enter Name   </label>
                                        <input name="personName" type="text" onChange={this.SetPersonName} />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <label>Chose Country   </label>
                                        <select name="allCountries" onChange={this.SetPersonCountry}>
                                            <option value="NotSelected">..Select Country..</option>
                                            {AvailableCountryList}
                                        </select>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <label>Chose city  </label>
                                        <select name="allCities" onChange={this.SetPersonCity}>
                                            <option value="NotSelected">..Select City..</option>
                                            {AvailableCityList}
                                        </select>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <label>Enter Telephone number : </label>
                                        <input type="text" name="personPhoneNumber" onChange={this.SetPersonPhoneNumber} />
                                    </td>
                                </tr>
                                <tr>
                                    <button type="submit" className="btn btn-outline-primary"> Add Person </button>
                                    <p>{this.state.errorMsg}</p>
                                </tr>
                            </tbody>
                        </table>
                    </form>
                </div>
            </div>
        );
    }
}

ReactDOM.render(<ReactApplication />, document.getElementById('application'));
