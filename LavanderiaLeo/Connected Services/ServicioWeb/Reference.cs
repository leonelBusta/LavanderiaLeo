//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace LavanderiaLeo.ServicioWeb {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServicioWeb.WSDireccionesSoap")]
    public interface WSDireccionesSoap {
        
        // CODEGEN: Se está generando un contrato de mensaje, ya que el nombre de elemento calle del espacio de nombres http://tempuri.org/ no está marcado para aceptar valores nil.
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/insDireccion", ReplyAction="*")]
        LavanderiaLeo.ServicioWeb.insDireccionResponse insDireccion(LavanderiaLeo.ServicioWeb.insDireccionRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/insDireccion", ReplyAction="*")]
        System.Threading.Tasks.Task<LavanderiaLeo.ServicioWeb.insDireccionResponse> insDireccionAsync(LavanderiaLeo.ServicioWeb.insDireccionRequest request);
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class insDireccionRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="insDireccion", Namespace="http://tempuri.org/", Order=0)]
        public LavanderiaLeo.ServicioWeb.insDireccionRequestBody Body;
        
        public insDireccionRequest() {
        }
        
        public insDireccionRequest(LavanderiaLeo.ServicioWeb.insDireccionRequestBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://tempuri.org/")]
    public partial class insDireccionRequestBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public string calle;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=1)]
        public string Numero;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=2)]
        public string Colonia;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=3)]
        public string Ciudad;
        
        public insDireccionRequestBody() {
        }
        
        public insDireccionRequestBody(string calle, string Numero, string Colonia, string Ciudad) {
            this.calle = calle;
            this.Numero = Numero;
            this.Colonia = Colonia;
            this.Ciudad = Ciudad;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class insDireccionResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="insDireccionResponse", Namespace="http://tempuri.org/", Order=0)]
        public LavanderiaLeo.ServicioWeb.insDireccionResponseBody Body;
        
        public insDireccionResponse() {
        }
        
        public insDireccionResponse(LavanderiaLeo.ServicioWeb.insDireccionResponseBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://tempuri.org/")]
    public partial class insDireccionResponseBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=0)]
        public int insDireccionResult;
        
        public insDireccionResponseBody() {
        }
        
        public insDireccionResponseBody(int insDireccionResult) {
            this.insDireccionResult = insDireccionResult;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface WSDireccionesSoapChannel : LavanderiaLeo.ServicioWeb.WSDireccionesSoap, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class WSDireccionesSoapClient : System.ServiceModel.ClientBase<LavanderiaLeo.ServicioWeb.WSDireccionesSoap>, LavanderiaLeo.ServicioWeb.WSDireccionesSoap {
        
        public WSDireccionesSoapClient() {
        }
        
        public WSDireccionesSoapClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public WSDireccionesSoapClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public WSDireccionesSoapClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public WSDireccionesSoapClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        LavanderiaLeo.ServicioWeb.insDireccionResponse LavanderiaLeo.ServicioWeb.WSDireccionesSoap.insDireccion(LavanderiaLeo.ServicioWeb.insDireccionRequest request) {
            return base.Channel.insDireccion(request);
        }
        
        public int insDireccion(string calle, string Numero, string Colonia, string Ciudad) {
            LavanderiaLeo.ServicioWeb.insDireccionRequest inValue = new LavanderiaLeo.ServicioWeb.insDireccionRequest();
            inValue.Body = new LavanderiaLeo.ServicioWeb.insDireccionRequestBody();
            inValue.Body.calle = calle;
            inValue.Body.Numero = Numero;
            inValue.Body.Colonia = Colonia;
            inValue.Body.Ciudad = Ciudad;
            LavanderiaLeo.ServicioWeb.insDireccionResponse retVal = ((LavanderiaLeo.ServicioWeb.WSDireccionesSoap)(this)).insDireccion(inValue);
            return retVal.Body.insDireccionResult;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<LavanderiaLeo.ServicioWeb.insDireccionResponse> LavanderiaLeo.ServicioWeb.WSDireccionesSoap.insDireccionAsync(LavanderiaLeo.ServicioWeb.insDireccionRequest request) {
            return base.Channel.insDireccionAsync(request);
        }
        
        public System.Threading.Tasks.Task<LavanderiaLeo.ServicioWeb.insDireccionResponse> insDireccionAsync(string calle, string Numero, string Colonia, string Ciudad) {
            LavanderiaLeo.ServicioWeb.insDireccionRequest inValue = new LavanderiaLeo.ServicioWeb.insDireccionRequest();
            inValue.Body = new LavanderiaLeo.ServicioWeb.insDireccionRequestBody();
            inValue.Body.calle = calle;
            inValue.Body.Numero = Numero;
            inValue.Body.Colonia = Colonia;
            inValue.Body.Ciudad = Ciudad;
            return ((LavanderiaLeo.ServicioWeb.WSDireccionesSoap)(this)).insDireccionAsync(inValue);
        }
    }
}
