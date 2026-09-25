using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Assets._Project.Develop.Runtime.Gameplay.SequenceService
{
    public class Sequence
    {
        private Dictionary<KeyCode,char> _sequencePool;

        private List<char> _sequenceValues;

        private int _sequenceLenth;

        private Queue<char> _currentSequence;

        public Sequence(Dictionary<KeyCode,char> sequencePool, int sequenceLenth)
        {
            _sequencePool = sequencePool;
            _sequenceLenth = sequenceLenth;

            _currentSequence = new();
        }

        public void Create()
        {
            if (_sequenceValues == null)
                SetValues();

            Reset();

            for (int i = 0; i < _sequenceLenth; i++)
                AddRandomValueToSequence();
        }

        public KeyCode GetNextValueKeyCode()
        {
            if (_currentSequence == null)
                throw new NullReferenceException("Sequense is null, please create the sequence before using");

            char value = _currentSequence.Dequeue();
            KeyCode valueKeyCode = _sequencePool.First(kvp => kvp.Value.Equals(value)).Key;

            return valueKeyCode;
        }

        public string Get()
        {
            string sequence = "";
            for (int i = 0; i < _sequenceLenth; i++)
            {
                char value = _currentSequence.Dequeue();
                sequence += value;
                _currentSequence.Enqueue(value);
            }

            return sequence;
        }

        private void Reset() => _currentSequence.Clear();

        private void SetValues()
        {
            _sequenceValues = new();

            foreach (var kvp in _sequencePool)
                _sequenceValues.Add(kvp.Value);
        }

        private void AddRandomValueToSequence()
        {
            char randomValue = _sequenceValues[Random.Range(0, _sequenceValues.Count)];
            _currentSequence.Enqueue(randomValue);
        }
    }
}