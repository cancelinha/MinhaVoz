import React, { Component } from 'react';
import Logo from '../../assets/imagens/minhavoz-logo.png'
import Axios from 'axios';

class PainelAdm extends Component {
    constructor() {
        super();
        this.state = {
            chamado: [],
            id: '',
            nome: '',
            email: '',
            telefone: '',
            titulo: '',
            assunto: '',
            descricao: '',
            status: '',
            data: '',
            qtdChamado: '',
            listaChamados: [],
            a: [],
            idSelecionado: ''
        }
    }


    Sair(event) {
        event.preventDefault();
        localStorage.removeItem("usuario");
        this.props.history.push("/");
    }

    componentDidMount() {
        this.listarChamados();
    }

    listarChamados() {

        Axios.get("http://192.168.4.32:5000/listar",
            {
                headers: {
                    "Content-Type": "application/json",
                    'Authorization': "Bearer " + localStorage.getItem("usuario")
                }
            })
            .then((response) => {
                console.log(response);

                // var somaPendentes = response.data.reduce( function( obj, v ) {
                //     obj[v.status] = (obj[v.status] || 0) + 1;
                //     return obj;
                // }, {} );

                // console.log(response.request);
                // console.log(response.config);
                console.log(response.data);
                // console.log(response.headers);
                // console.log(response.statusText);
                // console.log(response.status);

                var resData = response.data;
                // var a = resData['status'];
                // var json = JSON.parse(resData);
                // console.log(resData[0].status);

                // if (resData[0].status === "Pendente" || resData[0].status === "Em Análise"){

                // }

                function pegarPendentes(resData) {
                    return (resData.status === "Pendente" || resData.status === "Em Análise");
                }

                //   function myFunction() {
                var a = resData.filter(pegarPendentes).length;
                //   }
                console.log(a);
                // const somaPendentes = response.data;
                // if (somaPendentes.status === "Em Análise" || somaPendentes.status === "Pendente") {
                //     return somaPendentes.length;
                // }

                const qtdChamado = response.data.length;
                response = this.setState({ listaChamados: response.data, qtdChamado, a })
                // console.log(qtdChamado);
            })
            .catch((erro) => console.log(erro))
    }

    // verificaStatus = (chamado) => {
    //     // if (chamado.status === "Atendido") {
    //     //     return (
    //     //         <div>
    //     //             <div style={{ backgroundColor: 'green' }}>
    //     //                 {chamado.status}
    //     //             </div>
    //     //         </div>
    //     //     );
    //     // } else 
    //     // if (chamado.status === "Em Análise") {
    //     //     var cor = 'yellow';
    //     //     return(cor); 
    //     //     // return (

    //     //     //     <div>
    //     //     //         <div style={{ backgroundColor: 'yellow' }}>
    //     //     //             {chamado.status}
    //     //     //         </div>
    //     //     //     </div>
    //     //     // );
    //     // } else {
    //     //     return (
    //     //         null
    //     //     );
    //     // }
    //     if(chamado.status === "Banana"){
    //         cor ="<p>TESTE DA BANANA</p>"
    //         return(cor);
    //     }
    // }

    // qtdChamadoPendente(){
    //     this.qtdChamado.filter() 
    // }

    alterarStatus(event, chamado) {
        event.preventDefault();
        const dados = {
            // id: this.state.id,
            status: this.state.status
        }
        // console.log(this.state.idSelecionado)
        console.log(this.state)
        // console.log(dados)
        
        Axios.put(`http://192.168.4.32:5000/api/Chamados/editarstatus/${this.state.idSelecionado}`,
            dados,
            {
                headers: {
                    "Content-Type": "application/json",
                    "Authorization": "Bearer " + localStorage.getItem("usuario"),
                }
            })
            
            .then(data => {
                console.log(data.status)
                if (data.status === 200) {
                    this.setState({ Mensagem: 'Atualização bem sucedida.' });
                    this.props.history.push("/painel")
                    window.location.reload();
                }
                if (data.status === 401) {
                        alert('Sessão expirada. É necessário estar logado para acessar esta página');
                        this.props.history.push("/login")
                }
            })

            .catch(erro => {
                this.setState({ Mensagem: 'Ocorreu um erro, tente novamente.' + erro });
                console.error(erro)
            })
    }

    atualizarEstado = (event) => {
        console.log( event.target.value);
        this.setState({ [event.target.name]: event.target.value }, () =>{
            console.log( this.state);
        });
        
    }

    render() {

        return (
            <div>
                {/* <link href="https://fonts.googleapis.com/css?family=Montserrat&display=swap" rel="stylesheet"/> */}
                {/* ------------------------------ CONTAINER ------------------------------ */}
                <div style={{ height: '100%', margin: 0, display: 'flex', flexDirection: 'column', fontFamily: 'Montserrat' }}>

                    {/* ------------------------------ HEADER ------------------------------ */}
                    {/* <Cabecalho> */}
                    <div style={{
                        display: 'flex', flexDirection: 'row', alignItems: 'center',
                        // position: 'fixed', 
                        borderBottom: '1px solid #BF0811', backgroundColor: 'white', width: '100%', zIndex: 2, paddingBottom: '1.4%', paddingTop: '.8%'
                    }}>
                        <img src={Logo} style={{ width: '20%', height: '100%', marginLeft: '5%' }} alt='Logo SENAI' />
                        <div style={{ display: 'flex', justifyContent: "flex-end", width: '100%', marginRight: '5%' }}>
                            <span style={{ marginLeft: 'auto', textDecoration: 'none', color: 'black' }}>Bem vindo, <b>Administrador</b></span>
                            <a href='/login' onClick={this.Sair.bind(this)} style={{ marginLeft: 'auto', cursor: 'pointer', color: '#BF0811', fontWeight: '700' }}>Sair</a>
                        </div>
                    </div>
                    {/* ------------------------------ FIM HEADER ------------------------------ */}

                    {/* ------------------------------ BODY ------------------------------ */}
                    <div style={{ position: 'relative', zIndex: 1, overflow: 'auto', flex: 1, height: '100%', display: 'block' }}>

                        <p style={{ textAlign: 'start', marginInlineStart: '10%', marginBlockStart: '5%', fontWeight: 'bold', color: '#BF0811', fontSize: '1em' }}>PAINEL ADMINISTRATIVO</p>
                        <p style={{ textAlign: 'start', marginInlineStart: '10%', fontWeight: 'bold', fontSize: '2em', lineHeight: '0' }}> Chamados</p>

                        <div style={{ display: 'grid', gridTemplateColumns: '1fr 1fr', width: '100%' }}>

                            <div style={{
                                display: 'flex', flexDirection: 'column',
                                // margin: 'auto',
                                marginLeft: '20%',
                                marginRight: '2%',
                                paddingBottom: '3%',
                                border: '2px solid #f2f2f2',
                                boxShadow: '1px 1px 6px 0px #F9F9F9',
                                borderRadius: '3px'
                            }}>
                                <h3 style={{ fontSize: '16px', textAlign: 'left', textTransform: 'capitalize', color: '#BF0811', paddingLeft: '5%' }}>TOTAL DE CHAMADOS PENDENTES:</h3>
                                {/* Contador de chamados pendentes */}
                                <p style={{ textAlign: 'center', fontSize: '3em', fontWeight:'700', margin: '0' }}>
                                    {/* {this.qtdChamadoPendente()} */}
                                    {this.state.a}
                                </p>
                            </div>

                            <div style={{
                                display: 'flex', flexDirection: 'column',
                                // margin: 'auto', 
                                marginRight: '20%',
                                // marginLeft: '2%',
                                border: '2px solid #f2f2f2',
                                boxShadow: '1px 1px 6px 0px #f2f2f2',
                                borderRadius: '3px'
                            }}>
                                <h3 style={{ fontSize: '16px', textAlign: 'left', textTransform: 'capitalize', color: '#BF0811', paddingLeft: '5%' }}>TOTAL DE CHAMADOS:</h3>
                                <p style={{ textAlign: 'center', fontSize: '3em', fontWeight:'700', margin: '0' }}>{this.state.qtdChamado}</p>
                            </div>

                        </div>

                        {/* ------------------------------ EDITAR ------------------------------ */}


                        <div style={{paddingTop: '8%', paddingLeft: '11%'}}>
                        <p style={{fontWeight: 'bold', fontSize: '2em', lineHeight: '0', paddingBottom: '2%' }}> Alterar chamado</p>

                        
                            <form onSubmit={this.alterarStatus.bind(this)}>
                            <label>Selecione o ID do chamado:</label>

                            <div style={{display: 'inline-block', paddingLeft:'10px'}}>
                                <select style={{height: '30px', width:'180px'}} name="idSelecionado" onChange={this.atualizarEstado} required>
                                <option defaultValue> </option>
                                    {
                                        this.state.listaChamados.map(function (chamado) {
                                            return (
                                                <option key={chamado.id} value={chamado.id}>
                                                    {chamado.id}
                                                </option>
                                            );
                                        })
                                    }
                                </select>
                            </div>

                            <label style={{padding: '0 10px 0 2%'}}>Selecione o status do chamado:</label>
                            
                            <select
                                value={this.state.status}
                                name="status"
                                onChange={this.atualizarEstado}
                                style={{height: '30px', width: '190px'}}
                                
                            >
                                <option defaultValue> </option>
                                <option value="Arquivado">Arquivado</option>
                                <option value='Em Análise'>Em Análise</option>
                                <option value='Atendido'>Atendido</option>
                            </select>

                            {/* <input value={this.state.status}
                                    type='text'
                            name='status'
                                        required
                                        onChange={this.atualizarEstado}></input> */}

                            <button style={{border:'none', borderRadius: '0 3px 3px 0', backgroundColor:'black', padding: '2px 20px 0 20px', height: '30px', color: 'white', fontFamily:'Montserrat', }}type="submit">Alterar status</button>
                        </form>
                    </div>
                        {/* ------------------------------ FIM EDITAR ------------------------------ */}

                        <div>

                            <div style={{
                                display: 'grid',
                                gridTemplateColumns: '1fr 1fr',
                                gridTemplateAreas: `'chamado data' 'nome email' 'telefone assunto ' 'titulo titulo' 'mensagem mensagem' 'status status'`,
                                width: '80%',
                                margin: '1% 10% 2% 10%'
                            }}>
                                {
                                    this.state.listaChamados.map(function (chamado) {
                                        if (chamado.status === "Em Análise" || chamado.status === "Pendente") {
                                            return (
                                                <div key={chamado.id} style={{ border: '2px solid #f2f2f2', margin: '1% 2% 2% 0', boxShadow: '1px 1px 10px 0px #F9F9F9', padding: '2% 6%', borderRadius: '3px' }}>
                                                    <h2 style={{ gridArea: 'chamado', textAlign: 'center' }}><b>Chamado #  {chamado.id}</b></h2>
                                                    <p style={{ gridArea: 'data', padding: '1%' }}><b>Data do chamado:</b>  {chamado.data.split("T")[0].split("-")[2]}/
                                                                                                                        {chamado.data.split("T")[0].split("-")[1]}/
                                                                                                                        {chamado.data.split("T")[0].split("-")[0]}</p>
                                                    <p style={{ gridArea: 'nome', padding: '1%' }}><b>Nome:</b>                {chamado.nome}</p>
                                                    <p style={{ gridArea: 'email', padding: '1%' }}><b>Email:</b>              {chamado.email}</p>
                                                    <p style={{ gridArea: 'telefone', padding: '1%' }}><b>Telefone:</b>        {chamado.telefone}</p>
                                                    <p style={{ gridArea: 'assunto', padding: '1%' }}><b>Assunto:</b>          {chamado.assunto}</p>
                                                    <p style={{ gridArea: 'titulo', padding: '1%' }}><b>Título:</b>            {chamado.titulo}</p>
                                                    <p style={{ gridArea: 'mensagem', padding: '1%' }}><b>Mensagem:</b>        {chamado.descricao}</p>
                                                    <div style={{ gridArea: 'status', padding: '1%', margin: 'auto', display: 'flex', flexDirection: 'row', justifyContent: 'center', alignItems: 'center', borderTop: '1px solid #cccccc' }}>
                                                        <p style={{ paddingRight: '1%' }}><b>Status:</b></p>

                                                        <div style={{ color: 'orange', fontWeight: 'bolder', fontStyle: 'italic' }}>

                                                            {chamado.status.toUpperCase()}
                                                            {/* {this.verificaStatus(chamado)}
                                                        {cor} */}
                                                        </div>
                                                    </div>
                                                </div>
                                            );
                                        } else if (chamado.status === "Atendido" || chamado.status === "Resolvido") {
                                            return (
                                                <div key={chamado.id} style={{ border: '2px solid #f2f2f2', margin: '2%', boxShadow: '1px 1px 10px 0px #F9F9F9', padding: '2% 6%', borderRadius: '3px' }}>
                                                    <h2 style={{ gridArea: 'chamado', textAlign: 'center' }}><b>Chamado #  {chamado.id}</b></h2>
                                                    <p style={{ gridArea: 'data', padding: '1%' }}><b>Data do chamado:</b>  {chamado.data.split("T")[0].split("-")[2]}/
                                                                                                                        {chamado.data.split("T")[0].split("-")[1]}/
                                                                                                                        {chamado.data.split("T")[0].split("-")[0]}</p>
                                                    <p style={{ gridArea: 'nome', padding: '1%' }}><b>Nome:</b>                {chamado.nome}</p>
                                                    <p style={{ gridArea: 'email', padding: '1%' }}><b>Email:</b>              {chamado.email}</p>
                                                    <p style={{ gridArea: 'telefone', padding: '1%' }}><b>Telefone:</b>        {chamado.telefone}</p>
                                                    <p style={{ gridArea: 'assunto', padding: '1%' }}><b>Assunto:</b>          {chamado.assunto}</p>
                                                    <p style={{ gridArea: 'titulo', padding: '1%' }}><b>Título:</b>            {chamado.titulo}</p>
                                                    <p style={{ gridArea: 'mensagem', padding: '1%' }}><b>Mensagem:</b>        {chamado.descricao}</p>
                                                    <div style={{ gridArea: 'status', padding: '1%', margin: 'auto', display: 'flex', flexDirection: 'row', justifyContent: 'center', alignItems: 'center', borderTop: '1px solid #BF0811' }}>
                                                        <p style={{ paddingRight: '1%' }}><b>Status:</b></p>

                                                        <div style={{ color: '#0891bf', fontWeight: 'bolder', fontStyle: 'italic' }}>

                                                            {chamado.status.toUpperCase()}
                                                            {/* {this.verificaStatus(chamado)}
                                                            {cor} */}
                                                        </div>
                                                    </div>
                                                </div>
                                            );
                                        } else {
                                            return (
                                                <div key={chamado.id} style={{ border: '2px solid #f2f2f2', margin: '1% 2% 2% 0', boxShadow: '1px 1px 10px 0px #F9F9F9', padding: '2% 6%', borderRadius: '3px' }}>
                                                    <h2 style={{ gridArea: 'chamado', textAlign: 'center' }}><b>Chamado #  {chamado.id}</b></h2>
                                                    <p style={{ gridArea: 'data', padding: '1%' }}><b>Data do chamado:</b>  {chamado.data.split("T")[0].split("-")[2]}/
                                                                                                                        {chamado.data.split("T")[0].split("-")[1]}/
                                                                                                                        {chamado.data.split("T")[0].split("-")[0]}</p>
                                                    <p style={{ gridArea: 'nome', padding: '1%' }}><b>Nome:</b>                {chamado.nome}</p>
                                                    <p style={{ gridArea: 'email', padding: '1%' }}><b>Email:</b>              {chamado.email}</p>
                                                    <p style={{ gridArea: 'telefone', padding: '1%' }}><b>Telefone:</b>        {chamado.telefone}</p>
                                                    <p style={{ gridArea: 'assunto', padding: '1%' }}><b>Assunto:</b>          {chamado.assunto}</p>
                                                    <p style={{ gridArea: 'titulo', padding: '1%' }}><b>Título:</b>            {chamado.titulo}</p>
                                                    <p style={{ gridArea: 'mensagem', padding: '1%' }}><b>Mensagem:</b>        {chamado.descricao}</p>
                                                    <div style={{ gridArea: 'status', padding: '1%', margin: 'auto', display: 'flex', flexDirection: 'row', justifyContent: 'center', alignItems: 'center', borderTop: '1px solid #cccccc' }}>
                                                        <p style={{ paddingRight: '1%' }}><b>Status:</b></p>

                                                        <div style={{ color: '#0891bf', fontWeight: 'bolder', fontStyle: 'italic' }}>

                                                            {chamado.status.toUpperCase()}
                                                            {/* {this.verificaStatus(chamado)}
                                                            {cor} */}
                                                        </div>
                                                    </div>
                                                </div>
                                            );
                                        }
                                    })
                                }
                            </div>

                        </div>
                    </div>
                    {/* ------------------------------ FIM BODY ------------------------------ */}
                </div>
                {/* ------------------------------ FIM CONTAINER ------------------------------ */}
            </div>
        );
    }
}

export default PainelAdm;