package cr.ac.ucr.teleatlantico.service;

import java.util.List;
import java.util.NoSuchElementException;

import javax.transaction.Transactional;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import cr.ac.ucr.teleatlantico.domain.Client;
import cr.ac.ucr.teleatlantico.repository.ClientRepository;

@Service
@Transactional
public class ClientService {

	@Autowired
	private ClientRepository repository;
	
	public List<Client> listAll() {
		return repository.findAll();
	}

	public Client save(Client client) {
		client.encryptPassword();
		return repository.save(client);
	}
	
	public Client update(Client client) {
		if(!repository.existsById(client.getClientId()))
			throw new NoSuchElementException("Client does not exists!");
		return repository.save(client);
	}

	public Client get(int id) {
		return repository.findById(id).get();
	}

	public void delete(int id) {
		repository.deleteById(id);
	}
	

	public Client get(String email) {
		return repository.findByEmail(email);
	}
}
