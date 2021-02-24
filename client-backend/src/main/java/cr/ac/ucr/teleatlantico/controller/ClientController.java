package cr.ac.ucr.teleatlantico.controller;

import java.security.Principal;
import java.util.Date;
import java.util.List;
import java.util.NoSuchElementException;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.dao.DataIntegrityViolationException;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.CrossOrigin;
import org.springframework.web.bind.annotation.DeleteMapping;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.PutMapping;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.ResponseBody;
import org.springframework.web.bind.annotation.RestController;

import cr.ac.ucr.teleatlantico.domain.Client;
import cr.ac.ucr.teleatlantico.service.ClientService;

@CrossOrigin(origins = "http://localhost:4200")
@RestController
@RequestMapping("/client")
public class ClientController {

	@Autowired
	private ClientService service;
	
	@GetMapping("/clients")
	public List<Client> list() {
		return service.listAll();
	}

	@GetMapping("/{id}")
	public ResponseEntity<Client> get(@PathVariable int id) {
		try {
			Client client = service.get(id);
			return new ResponseEntity<Client>(client, HttpStatus.OK);
		} catch (NoSuchElementException e) {
			return new ResponseEntity<Client>(HttpStatus.NOT_FOUND);
		}
	}
	
	
	@PostMapping(value="/add", consumes="application/json")
	public ResponseEntity<Client> add(@RequestBody Client client) {
		client.setCreateAt(new Date());
		client.setModifyAt(null);
		client.setCreateBy(client.getFirstSurname()+"-"+client.getName());
		try {
			service.save(client);
			return new ResponseEntity<Client>(client, HttpStatus.OK);
		} catch (DataIntegrityViolationException e) {
			return new ResponseEntity<Client>(HttpStatus.CONFLICT);
		}
	}

	@PostMapping("/addIssue")
	public ResponseEntity<Client> addIssue(@RequestBody Client client) {
		try {
			service.update(client);
			return new ResponseEntity<Client>(client, HttpStatus.OK);
		} catch (NoSuchElementException e) {
			return new ResponseEntity<Client>(HttpStatus.NOT_FOUND);
		}
	}

	@DeleteMapping("/delete/{id}")
	public void delete(@PathVariable int id) {
		service.delete(id);
	}
}
